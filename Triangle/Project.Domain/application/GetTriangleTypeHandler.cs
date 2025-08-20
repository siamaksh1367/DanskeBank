using MediatR;
using Project.Domain.services;

namespace Project.Domain.application
{
    public class GetTriangleTypeHandler : IRequestHandler<GetTriangleTypeQuery, string>
    {
        private readonly IShapeService<IEnumerable<double>, string> service;

        public GetTriangleTypeHandler(IShapeService<IEnumerable<double>, string> service)
        {
            this.service = service;
        }
        public Task<string> Handle(GetTriangleTypeQuery request, CancellationToken cancellationToken)
        {
            var sideValues = request.Sides.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToList();
            return Task.FromResult(service.Process(sideValues));
        }
    }
}
