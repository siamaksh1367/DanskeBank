using AutoMapper;
using Project.dal.Models;

namespace Project.core.Commands.UpdateCategory
{
    public class UpdateCategoryResponse
    {
        public int Id { get; }
        public string Name { get; }
        public string Description { get; }
        public UpdateCategoryResponse(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }



    public class UpdateCategoryResponseMappingProfile : Profile
    {
        public UpdateCategoryResponseMappingProfile()
        {
            CreateMap<Category, UpdateCategoryResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));

        }
    }
}
