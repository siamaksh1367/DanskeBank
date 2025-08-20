using MediatR;

namespace Project.core.Shared
{
    public interface IQuery<out TResponse> : IRequest<TResponse>
    {
    }
}
