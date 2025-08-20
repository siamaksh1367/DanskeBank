using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Project.Domain.application;
using Project.Domain.context;
using Project.Domain.errors;
using Project.Domain.services;
using Project.Domain.strategies;
using Project.Domain.Strategies;
using Project.Domain.validation;

namespace Project
{
    public class Program
    {
        static void Main()
        {
            var serviceProvider = new ServiceCollection()
                .AddTransient<IApplication, Application>()
                .AddTransient<IShapeService<IEnumerable<double>, string>, TriangleService>()
                .AddTransient<ITriangleTypeContext, TriangleTypeContext>()
                .AddTransient<ITriangleTypeStrategy, EquilateralStrategy>()
                .AddTransient<ITriangleTypeStrategy, IsoscelesStrategy>()
                .AddTransient<ITriangleTypeStrategy, ScaleneStrategy>()
                .AddTransient<IApplication, Application>()
                .AddMediatR(cfg =>
                {
                    cfg.RegisterServicesFromAssembly(typeof(GetTriangleTypeHandler).Assembly);
                })
                .AddValidatorsFromAssembly(typeof(GetTriangleQueryValidator).Assembly)
                .AddTransient(typeof(IPipelineBehavior<,>), typeof(ExceptionHandlerPipelineBehavior<,>))
                .AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>))
                .AddLogging(builder => builder.AddConsole())
                .BuildServiceProvider();

            var service = serviceProvider.GetRequiredService<IApplication>();

            service.RunAsync();
        }
    }
}
