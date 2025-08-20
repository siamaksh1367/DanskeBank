using Project.core.Queries.GetPost;
using Microsoft.AspNetCore.Components;

namespace Project.web.Components
{
    public partial class PostCard
    {
        [Parameter]
        public GetPostResponse GetPostResponse { get; set; }

        private void NavigateToPostDetails()
        {
            NavigationManager.NavigateTo($"/post/{GetPostResponse.Id}");
        }
    }
}