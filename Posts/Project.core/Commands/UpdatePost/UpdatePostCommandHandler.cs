using AutoMapper;
using Project.core.Services.ContentStorage;
using Project.core.Shared;
using Project.dal.Generic;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Project.core.Commands.CreateComment
{
    public class UpdatePostCommandHandler : ICommandHandler<UpdatePostCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IContentStorage _contentStorage;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UpdatePostCommandHandler(IUnitOfWork unitOfWork, IContentStorage contentStorage, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _contentStorage = contentStorage;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<int> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
        {
            var post = await _unitOfWork.Posts.GetPostWithDetails(request.Id);
            if (post == null)
            {
                throw new UnauthorizedAccessException("No Post available.");
            }
            var userIdClaim = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);

            if (post.UserId != userIdClaim.Value)
            {
                throw new UnauthorizedAccessException("User is not authenticated.");
            }

            var currentTags = post.Tags.ToList();

            var newTags = request.Tags;

            foreach (var tag in currentTags)
            {
                if (!newTags.Contains(tag.Id))
                {
                    post.Tags.Remove(tag);
                }
            }

            foreach (var tagId in newTags)
            {
                if (!post.Tags.Any(t => t.Id == tagId))
                {
                    var tag = await _unitOfWork.Tags.SingleOrDefaultAsync(x => x.Id == tagId);
                    if (tag != null)
                    {
                        post.Tags.Add(tag);
                    }
                }
            }

            post.Title = request.Title;
            var category = await _unitOfWork.Categories.SingleOrDefaultAsync(x => x.Id == request.CategoryId);
            post.Category = category;

            if (post.ContentKey == Guid.Empty)
            {
                post.ContentKey = new Guid();
            }

            await _contentStorage.AddImageByIdAsync(request.Image, post.ContentKey);
            await _contentStorage.AddStringByIdAsync(request.Content, post.ContentKey);

            await _unitOfWork.CompleteAsync();

            return post.Id;
        }
    }
}
