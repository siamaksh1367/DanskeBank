using Project.core.Shared;

namespace Project.core.Queries.GetPost
{
    public class GetPostQuery : IQuery<GetPostResponse>
    {
        public int Id { get; set; }
    }
}
