using AutoMapper;
using Project.core.Services.ContentStorage;
using Project.core.Shared;
using Project.dal.Generic;

namespace Project.core.Queries.GetPost
{
    public sealed class GetPostQueryHandler : IQueryHandler<GetPostQuery, GetPostResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IContentStorage _contentStorage;

        public GetPostQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, IContentStorage contentStorage)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _contentStorage = contentStorage;
        }

        public async Task<GetPostResponse> Handle(GetPostQuery request, CancellationToken cancellationToken)
        {
            var post = await _unitOfWork.Posts.GetPostWithDetails(request.Id);
            var response = _mapper.Map<GetPostResponse>(post);
            response.Content = await _contentStorage.GetFileByIdAsync(post.ContentKey);
            response.Image = await _contentStorage.GetImageByIdAsync(post.ContentKey);
            response.UserName = post.UserId;
            return response;
        }
    }
}
