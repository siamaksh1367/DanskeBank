using Project.core.Shared;

namespace Project.core.Commands.CreateComment
{
    public class UpdatePostCommand : ICommand<int>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public List<int> Tags { get; set; }
        public int CategoryId { get; set; }
        public byte[] Image { get; set; }
        public UpdatePostCommand(int id, string title, string content, List<int> tags, int categoryId, byte[] image)
        {
            Id = id;
            Title = title;
            Content = content;
            Tags = tags;
            CategoryId = categoryId;
            Image = image;
        }
    }

}
