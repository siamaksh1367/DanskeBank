using MediatR;
using Microsoft.Extensions.Logging;
using Project.Domain.application;

namespace Project
{
    public class Application : IApplication
    {
        private readonly IMediator _mediator;
        private readonly ILogger<Application> _log;

        public Application(IMediator mediator, ILogger<Application> log)
        {
            _mediator = mediator;
            _log = log;
        }

        public async Task RunAsync()
        {
            try
            {
                var triangleType = await _mediator.Send(new GetTriangleTypeQuery() { Sides = parseUserInput() });
                presentResultToUser(triangleType);
            }
            catch (Exception ex)
            {
                _log.Log(LogLevel.Error, ex.Message);
            }
        }

        private static void presentResultToUser(string triangleType)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"The provided set of numbers represent a {triangleType}");
        }

        private static string parseUserInput()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Please enter 3 numbers separated with space:");
            Console.ForegroundColor = ConsoleColor.Yellow;
            return Console.ReadLine();
        }
    }
}
