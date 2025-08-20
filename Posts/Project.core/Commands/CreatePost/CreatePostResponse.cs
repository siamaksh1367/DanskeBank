using AutoMapper;
using Project.dal.Models;

namespace Project.core.Commands.CreatePost
{
    public class CreatePostResponse
    {
        public DateTime LastEdited { get; set; }
        public string Title { get; set; }
        public IEnumerable<string> Tags { get; set; }
        public string CategoryName { get; set; }
        public int Id { get; set; }
        public string Content { get; set; }
    }

    public class CreatePostResponseMappingProfile : Profile
    {
        public CreatePostResponseMappingProfile()
        {
            CreateMap<Post, CreatePostResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.LastEdited, opt => opt.MapFrom(src => src.Created))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
                .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.Tags.Select(x => x.Name)));

        }
    }
}
