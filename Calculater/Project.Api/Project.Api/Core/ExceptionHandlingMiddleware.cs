using FluentValidation;
using System.Text.Json;

namespace Project.Api.Core
{

    public class ExceptionHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(ILogger<ExceptionHandlingMiddleware> logger)
            => _logger = logger;

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception exception)
            {
                LogWhenNeeded(exception);
                await HandleExceptionAsync(context, exception);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var (statusCode, errorResponse) = GetErrorResponse(exception);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;

            var jsonResponse = JsonSerializer.Serialize(errorResponse);
            await context.Response.WriteAsync(jsonResponse);
        }

        private (int StatusCode, object ErrorResponse) GetErrorResponse(Exception exception)
        {
            return exception switch
            {
                ValidationException validationException => (StatusCodes.Status422UnprocessableEntity,
                    new { Status = StatusCodes.Status422UnprocessableEntity, Errors = validationException.Errors.Select(x => $"{x.PropertyName}: {x.ErrorMessage}") }),

                ArgumentException => (StatusCodes.Status400BadRequest,
                    new { Status = StatusCodes.Status400BadRequest, Detail = exception.Message }),

                ApplicationException => (StatusCodes.Status500InternalServerError,
                    new { Status = StatusCodes.Status500InternalServerError, Detail = "An unexpected error occurred. Please try again later." }),

                _ => (StatusCodes.Status500InternalServerError,
                    new { Status = StatusCodes.Status500InternalServerError, Detail = "An unexpected error occurred. Please try again later." })
            };
        }

        private void LogWhenNeeded(Exception exception)
        {
            if (exception is not ValidationException && exception is not ApplicationException && exception is not ArgumentException)
            {
                _logger.LogError(exception, "Internal Server Error");
            }
        }
    }
}
