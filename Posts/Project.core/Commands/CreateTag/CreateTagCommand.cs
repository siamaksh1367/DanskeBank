using Project.core.Queries.GetTags;
using Project.core.Shared;

namespace Project.core.Commands.CreateTag
{
    public class CreateTagCommand : ICommand<GetTagResponse>
    {
        public string Name { get; set; }
        public CreateTagCommand(string name)
        {
            Name = name;
        }
    }
}
