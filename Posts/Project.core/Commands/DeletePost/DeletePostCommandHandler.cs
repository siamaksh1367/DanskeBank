using Project.core.Shared;
using Project.dal.Generic;

namespace Project.core.Commands.DeletePost
{
    public class DeletePostCommandHandler : ICommandHandler<DeletePostCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeletePostCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<int> Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            var category = await _unitOfWork.Posts.GetAsync(request.Id);
            _unitOfWork.Posts.Remove(category);
            await _unitOfWork.CompleteAsync();
            return request.Id;
        }
    }
}
