using AutoMapper;
using Project.dal.Models;

namespace Project.core.Commands.CreateCategory
{
    public class CreateCategoryResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public CreateCategoryResponse(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }

    public class CreateCategoryResponseMappingProfile : Profile
    {
        public CreateCategoryResponseMappingProfile()
        {
            CreateMap<Category, CreateCategoryResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));

        }
    }
}
