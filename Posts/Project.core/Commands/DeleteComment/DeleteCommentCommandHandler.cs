using Project.core.Shared;

namespace Project.core.Commands.DeleteComment
{
    public class DeleteCommentCommandHandler : ICommandHandler<DeleteCommentCommand, int>
    {
        public Task<int> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
