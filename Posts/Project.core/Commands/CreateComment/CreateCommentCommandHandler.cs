using AutoMapper;
using Project.core.Queries.GetComments;
using Project.core.Services.ContentStorage;
using Project.core.Shared;
using Project.dal.Generic;
using Project.dal.Models;

namespace Project.core.Commands.CreateComment
{
    public class CreateCommentCommandHandler : ICommandHandler<CreateCommentCommand, GetCommentResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IContentStorage _contentStorage;
        private readonly IMapper _mapper;
        private readonly IUserInfo _userInfo;

        public CreateCommentCommandHandler(IUnitOfWork unitOfWork, IContentStorage contentStorage, IMapper mapper, IUserInfo userInfo)
        {
            _unitOfWork = unitOfWork;
            _contentStorage = contentStorage;
            _mapper = mapper;
            _userInfo = userInfo;
        }
        public async Task<GetCommentResponse> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = new Comment();
            comment.PostId = request.PostId;
            comment.Content = request.Content;
            comment.UserId = _userInfo.GetUserId();
            comment.Created = DateTime.UtcNow;
            var createdComment = await _unitOfWork.Comments.AddAsync(comment);
            await _unitOfWork.CompleteAsync();
            return _mapper.Map<GetCommentResponse>(createdComment);

        }
    }
}
