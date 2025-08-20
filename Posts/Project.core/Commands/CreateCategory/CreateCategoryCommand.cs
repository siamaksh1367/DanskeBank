using AutoMapper;
using Project.core.Shared;
using Project.dal.Models;
using System.ComponentModel.DataAnnotations;

namespace Project.core.Commands.CreateCategory
{
    //comment
    public class CreateCategoryCommand : ICommand<CreateCategoryResponse>
    {
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }

        public CreateCategoryCommand(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }


    public class CreateCategoryCommandMappingProfile : Profile
    {
        public CreateCategoryCommandMappingProfile()
        {
            CreateMap<CreateCategoryCommand, Category>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));
        }
    }
}