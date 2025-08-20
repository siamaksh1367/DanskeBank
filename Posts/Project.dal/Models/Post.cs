namespace Project.dal.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastEdited { get; set; }
        public Guid ContentKey { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<Tag> Tags { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
