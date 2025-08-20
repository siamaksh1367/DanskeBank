
using Project.Api.Core;
using Project.Api.Core.Queries.WithdrawalQuery;
using Project.Api.Core.Services.WithdrawalServices;
using FluentValidation;
using MediatR;

namespace Project.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddMediatR(cfg =>
                cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>))
                    .AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>))
                    .AddBehavior(typeof(IPipelineBehavior<,>), typeof(ExceptionHandlingBehavior<,>))
                    .RegisterServicesFromAssemblies(typeof(Program).Assembly)
            );
            builder.Services.AddTransient<IValidator<WithdrawalQuery>, WithdrawalQueryValidator>();
            builder.Services.AddTransient<ExceptionHandlingMiddleware>();


            builder.Services.AddTransient<IWithdrawalService<WithdrawalQueryResponse>, WithdrawalService>();
            builder.Services.AddTransient<IWithdrawalStrategyFactory<Withdrawal>, WithdrawalStrategyFactory>();
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    policy =>
                    {
                        policy.AllowAnyOrigin()
                              .AllowAnyHeader()
                              .AllowAnyMethod();
                    });
            });

            var app = builder.Build();

            // Use CORS
            app.UseCors("AllowAllOrigins");

            // Configure the HTTP request pipeline.
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.UseMiddleware<ExceptionHandlingMiddleware>();

            app.MapControllers();
            app.Use(async (context, next) =>
            {
                if (context.Request.Path == "/")
                {
                    context.Response.Redirect("/swagger");
                    return;
                }
                await next();
            });
            app.Run();
        }
    }
}
