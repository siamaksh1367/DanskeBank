using Project.core.Shared;

namespace Project.core.Commands.UpdateComment
{
    public class UpdateCommentCommandHandler : ICommandHandler<UpdateCommentCommand, UpdateCommentResponse>
    {
        public Task<UpdateCommentResponse> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }

}
