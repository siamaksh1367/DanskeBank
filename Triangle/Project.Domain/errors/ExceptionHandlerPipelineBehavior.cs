using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Project.Domain.errors
{
    public class ExceptionHandlerPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : class, IRequest<TResponse>
    {
        private readonly ILogger<ExceptionHandlerPipelineBehavior<TRequest, TResponse>> _log;

        public ExceptionHandlerPipelineBehavior(ILogger<ExceptionHandlerPipelineBehavior<TRequest, TResponse>> log)
        {
            this._log = log;
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            try
            {
                return await next();
            }
            catch (ValidationException ex)
            {
                throw ex;
            }
        }
    }
}
