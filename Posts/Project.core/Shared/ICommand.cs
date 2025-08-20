using MediatR;

namespace Project.core.Shared
{
    public interface ICommand<out TResponse> : IRequest<TResponse>
    {
    }
}
