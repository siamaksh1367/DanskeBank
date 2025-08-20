namespace Project.core.Queries.GetPost
{
    public class GetPostResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int CommentsCount { get; set; }
        public Guid ContentKey { get; set; }
        public List<string> Tags { get; set; }
        public string Category { get; set; }
        public byte[] Image { get; set; }
        public string UserName { get; set; }
    }
}
