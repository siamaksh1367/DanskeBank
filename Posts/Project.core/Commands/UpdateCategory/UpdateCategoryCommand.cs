using Project.core.Shared;
using System.ComponentModel.DataAnnotations;

namespace Project.core.Commands.UpdateCategory
{
    public class UpdateCategoryCommand : ICommand<UpdateCategoryResponse>
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }

        // Constructor to initialize properties
        public UpdateCategoryCommand(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }

}
