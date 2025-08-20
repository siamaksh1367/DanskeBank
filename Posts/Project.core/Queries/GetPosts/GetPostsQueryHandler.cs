using AutoMapper;
using Project.common;
using Project.core.Queries.GetPost;
using Project.core.Services.ContentStorage;
using Project.core.Shared;
using Project.dal.Generic;

namespace Project.core.Queries.GetPosts
{
    public sealed class GetPostsQueryHandler : IQueryHandler<GetPostsQuery, WithCount<GetPostResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IContentStorage _contentStorage;
        private readonly IMapper _mapper;
        private readonly IUserInfo _userInfo;

        public GetPostsQueryHandler(IUnitOfWork unitOfWork, IContentStorage contentStorage, IMapper mapper, IUserInfo userInfo)
        {
            _unitOfWork = unitOfWork;
            _contentStorage = contentStorage;
            _mapper = mapper;
            _userInfo = userInfo;
        }

        public async Task<WithCount<GetPostResponse>> Handle(GetPostsQuery request, CancellationToken cancellationToken)
        {
            var posts = await _unitOfWork.Posts.GetPosts(request.TagIds, request.UserId, request.CategoryId, request.Offset, request.Limit);
            var responses = new WithCount<GetPostResponse>();
            responses.Response = new List<GetPostResponse>();
            foreach (var post in posts.Response)
            {
                var response = _mapper.Map<GetPostResponse>(post);
                response.Content = await _contentStorage.GetFileByIdAsync(post.ContentKey);
                response.Image = await _contentStorage.GetImageByIdAsync(post.ContentKey);
                response.UserName = post.UserId;
                responses.Response.Add(response);
            }
            responses.Count = posts.Count;
            return responses;
        }
    }
}
