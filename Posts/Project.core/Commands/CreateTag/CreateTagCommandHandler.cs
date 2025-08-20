using Project.core.Queries.GetTags;
using Project.core.Shared;
using Project.dal.Generic;
using Project.dal.Models;

namespace Project.core.Commands.CreateTag
{
    public sealed class CreateTagCommandHandler : ICommandHandler<CreateTagCommand, GetTagResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateTagCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<GetTagResponse> Handle(CreateTagCommand request, CancellationToken cancellationToken)
        {
            var addedTag = await _unitOfWork.Tags.AddAsync(new Tag() { Name = request.Name });
            await _unitOfWork.CompleteAsync();
            var tag = await _unitOfWork.Tags.SingleOrDefaultAsync(x => x.Id == addedTag.Id);
            return new GetTagResponse() { Id = tag.Id, Name = tag.Name };

        }
    }
}
