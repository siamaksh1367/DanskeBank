using Project.core.Shared;

namespace Project.core.Queries.GetComments
{

    public class GetCommentsQuery : IQuery<IEnumerable<GetCommentResponse>>
    {
        public int PostId { get; set; }
    }
}
