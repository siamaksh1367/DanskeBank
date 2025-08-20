using AutoMapper;
using Project.core.Queries.GetPost;
using Project.dal.Models;

namespace Project.core.Queries.GetPosts
{
    public class GetPostsResponseMappingProfile : Profile
    {
        public GetPostsResponseMappingProfile()
        {
            CreateMap<Post, GetPostResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title.ToString()))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.Name))
                .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.Tags.Select(tag => tag.Name).ToList()))
                .ForMember(dest => dest.CommentsCount, opt => opt.MapFrom(src => src.Comments.Count))
                .ForMember(dest => dest.ContentKey, opt => opt.MapFrom(src => src.ContentKey))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.Image, opt => opt.Ignore())
                .ForMember(dest => dest.Content, opt => opt.Ignore());

        }
    }

}
