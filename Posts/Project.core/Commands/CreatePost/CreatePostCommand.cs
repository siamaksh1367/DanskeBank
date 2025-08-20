using AutoMapper;
using Project.core.Shared;
using Project.dal.Models;
using System.ComponentModel.DataAnnotations;

namespace Project.core.Commands.CreatePost
{
    public class CreatePostCommand : ICommand<CreatePostResponse>
    {
        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }

        public string Content { get; set; }
        public List<int> Tags { get; set; } = new();

        public int CategoryId { get; set; }


        public byte[] Image { get; set; }

        public CreatePostCommand() { }

        public CreatePostCommand(string title, string content, List<int> tags, int categoryId, byte[] image)
        {
            Title = title;
            Content = content;
            Tags = tags;
            CategoryId = categoryId;
            Image = image;
        }
    }

    public class CreatePostCommandMappingProfile : Profile
    {
        public CreatePostCommandMappingProfile()
        {
            CreateMap<CreatePostCommand, Post>()
               .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
               .ForMember(dest => dest.ContentKey, opt => opt.MapFrom(src => Guid.NewGuid()))
               .ForMember(dest => dest.Created, opt => opt.MapFrom(src => DateTime.UtcNow))
               .ForMember(dest => dest.LastEdited, opt => opt.MapFrom(src => DateTime.UtcNow))
               .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId))
               .ForMember(dest => dest.Category, opt => opt.Ignore())
               .ForMember(dest => dest.Tags, opt => opt.Ignore())
               .ForMember(dest => dest.Comments, opt => opt.Ignore());
        }
    }
}
