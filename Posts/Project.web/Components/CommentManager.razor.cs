using Blazored.Toast.Services;
using Project.contract.Services;
using Project.core.Commands.CreateComment;
using Project.core.Queries.GetComments;
using Microsoft.AspNetCore.Components;

namespace Project.web.Components
{
    public partial class CommentManager
    {
        [Parameter]
        public List<GetCommentResponse> Comments { get; set; }

        [Parameter]
        public int PostId { get; set; }
        [Parameter]
        public EventCallback<CreateCommentCommand> CreateCommand_Handler { get; set; }

        [Inject]
        public ICommentService CommentService { get; set; }

        public async Task CreateCommand_Handling(CreateCommentCommand command)
        {
            command.PostId = PostId;
            await CreateCommand_Handler.InvokeAsync(command);
            ToastService.ShowSuccess("Your action was successful!");
        }
    }
}