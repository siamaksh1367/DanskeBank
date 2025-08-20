using AutoMapper;
using Project.dal.Models;

namespace Project.core.Queries.GetTags
{

    public class GetTagsResponseMappingProfile : Profile
    {
        public GetTagsResponseMappingProfile()
        {
            CreateMap<Tag, GetTagResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        }
    }
}