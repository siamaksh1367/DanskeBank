using Project.core.Queries.GetComments;
using Project.core.Shared;

namespace Project.core.Commands.CreateComment
{
    public class CreateCommentCommand : ICommand<GetCommentResponse>
    {
        public string Content { get; set; }
        public int PostId { get; set; }

        public CreateCommentCommand(string content, int postId)
        {
            Content = content;
            PostId = postId;
        }
    }
}
