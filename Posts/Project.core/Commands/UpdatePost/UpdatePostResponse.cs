using AutoMapper;
using Project.dal.Models;

namespace Project.core.Commands.CreateComment
{
    public class UpdatePostResponse
    {
        public int Id { get; set; }
    }
    public class UpdatePostCommandMappingProfile : Profile
    {
        public UpdatePostCommandMappingProfile()
        {
            CreateMap<UpdatePostCommand, Post>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
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
