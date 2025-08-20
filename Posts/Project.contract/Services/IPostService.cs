using Project.core.Commands.CreateComment;
using Project.core.Commands.CreatePost;
using Project.core.Commands.DeletePost;
using Project.core.Queries.GetPost;
using Project.core.Queries.GetPosts;

namespace Project.contract.Services
{
    public interface IPostService
    {
        HttpRequestBuilder CreatePost(CreatePostCommand createPostCommand);
        HttpRequestBuilder GetPosts(GetPostsQuery getPostQuery);
        HttpRequestBuilder GetPost(GetPostQuery getPostQuery);
        HttpRequestBuilder DeletePost(DeletePostCommand deleteCommand);
        HttpRequestBuilder Update(UpdatePostCommand updatePostCommand);
    }

    public class PostService : IPostService
    {
        private const string EndPoint = "api/posts";
        private readonly HttpRequestBuilder _requestBuilder;

        public PostService(HttpRequestBuilder requestBuilder)
        {
            _requestBuilder = requestBuilder;
            _requestBuilder.AssignEndpoint(EndPoint);
        }
        public HttpRequestBuilder CreatePost(CreatePostCommand createPostCommand)
        {

            return _requestBuilder.SetMethod(HttpMethod.Post)
                 .SetJsonContent<CreatePostCommand>(createPostCommand);
        }
        public HttpRequestBuilder GetPosts(GetPostsQuery getPostPostQuery)
        {
            _requestBuilder.AssignEndpoint(EndPoint);

            if (getPostPostQuery.TagIds is not null)
            {
                foreach (var TagId in getPostPostQuery.TagIds)
                {
                    _requestBuilder.AddQueryParameter("tagids", TagId.ToString());
                }
            }

            if (getPostPostQuery.CategoryId > 0)
            {
                _requestBuilder.AddQueryParameter("categoryid", getPostPostQuery.CategoryId.ToString());
            }

            if (!string.IsNullOrEmpty(getPostPostQuery.UserId))
            {
                _requestBuilder.AddQueryParameter("userid", getPostPostQuery.UserId);
            }

            _requestBuilder.AddQueryParameter("offset", getPostPostQuery.Offset.ToString());
            _requestBuilder.AddQueryParameter("limit", getPostPostQuery.Limit.ToString());

            return _requestBuilder.SetMethod(HttpMethod.Get);
        }
        public HttpRequestBuilder GetPost(GetPostQuery getPostQuery)
        {
            return _requestBuilder.SetMethod(HttpMethod.Get)
                .AssignEndpoint($"{EndPoint}/{getPostQuery.Id}");
        }

        public HttpRequestBuilder DeletePost(DeletePostCommand deleteCommand)
        {
            return _requestBuilder.SetMethod(HttpMethod.Delete)
                .AssignEndpoint($"{EndPoint}/{deleteCommand.Id}");
        }

        public HttpRequestBuilder Update(UpdatePostCommand updatePostCommand)
        {
            return _requestBuilder.SetMethod(HttpMethod.Put)
                .AssignEndpoint($"{EndPoint}/{updatePostCommand.Id}")
                .SetJsonContent<UpdatePostCommand>(updatePostCommand);
        }
    }
}
