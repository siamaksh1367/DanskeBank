using MediatR;

namespace Project.Domain.application
{
    public class GetTriangleTypeQuery : IRequest<string>
    {
        public string Sides { get; set; }
    }
}
