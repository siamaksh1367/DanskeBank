using AutoMapper;
using Project.core.Services.ContentStorage;
using Project.core.Shared;
using Project.dal.Generic;
using Project.dal.Models;

namespace Project.core.Commands.CreatePost
{
    public sealed class CreatePostCommandHandler : ICommandHandler<CreatePostCommand, CreatePostResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IContentStorage _contentStorage;
        private readonly IMapper _mapper;
        private readonly IUserInfo _userInfo;

        public CreatePostCommandHandler(IUnitOfWork unitOfWork, IContentStorage contentStorage, IMapper mapper, IUserInfo userInfo)
        {
            _unitOfWork = unitOfWork;
            _contentStorage = contentStorage;
            _mapper = mapper;
            _userInfo = userInfo;
        }
        public async Task<CreatePostResponse> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            var post = _mapper.Map<Post>(request);

            post.Tags = new List<Tag>();
            foreach (var tagId in request.Tags)
            {

                var tag = await _unitOfWork.Tags.SingleOrDefaultAsync(x => x.Id == tagId);
                post.Tags.Add(tag);
            }

            var category = await _unitOfWork.Categories.SingleOrDefaultAsync(x => x.Id == request.CategoryId);
            _unitOfWork.Categories.Attach(category);

            post.Category = category;

            post.UserId = _userInfo.GetUserId();
            await _contentStorage.AddImageByIdAsync(request.Image, post.ContentKey);
            await _contentStorage.AddStringByIdAsync(request.Content, post.ContentKey);

            var result = await _unitOfWork.Posts.AddAsync(post);

            await _unitOfWork.CompleteAsync();

            var returedPost = _mapper.Map<CreatePostResponse>(result);
            returedPost.Content = request.Content;

            return returedPost;


        }
    }
}
