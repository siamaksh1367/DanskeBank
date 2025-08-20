using Project.core.Commands.CreateComment;
using Project.core.Queries.GetComments;

namespace Project.contract.Services
{
    //comment
    public interface ICommentService
    {
        HttpRequestBuilder GetCommentsForPost(GetCommentsQuery getCommentsQuery);
        HttpRequestBuilder CreateComment(CreateCommentCommand createCommentCommand);
    }

    public class CommentService : ICommentService
    {
        private const string EndPoint = "/api/comments";
        private readonly HttpRequestBuilder _requestBuilder;

        public CommentService(HttpRequestBuilder requestBuilder)
        {
            _requestBuilder = requestBuilder;
            _requestBuilder.AssignEndpoint(EndPoint);
        }
        public HttpRequestBuilder CreateComment(CreateCommentCommand createCommentCommand)
        {
            return _requestBuilder.SetMethod(HttpMethod.Post)
            .SetJsonContent<CreateCommentCommand>(createCommentCommand);
        }

        public HttpRequestBuilder GetCommentsForPost(GetCommentsQuery getCommentsQuery)
        {
            return _requestBuilder.SetMethod(HttpMethod.Get).AppendEndpoint($"comments/post/{getCommentsQuery.PostId}"); ;
        }
    }

}
