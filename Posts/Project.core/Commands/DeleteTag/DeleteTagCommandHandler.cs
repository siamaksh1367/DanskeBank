using Project.core.Shared;

namespace Project.core.Commands.DeleteTag
{
    public sealed class DeleteTagCommandHandler : ICommandHandler<DeleteTagCommand, int>
    {
        public Task<int> Handle(DeleteTagCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }

}
