using AutoMapper;
using Project.dal.Models;

namespace Project.core.Queries.GetComments
{
    public class GetCommentResponseMappingProfile : Profile
    {
        public GetCommentResponseMappingProfile()
        {
            // Mapping from Comment entity to GetCommentResponse DTO
            CreateMap<Comment, GetCommentResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content))
                .ForMember(dest => dest.Created, opt => opt.MapFrom(src => src.Created));
        }
    }
}
