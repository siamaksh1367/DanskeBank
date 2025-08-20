using Project.core.Queries.GetCategories;
using Project.core.Queries.GetPost;
using Project.core.Queries.GetPosts;
using Project.core.Queries.GetTags;
using Microsoft.AspNetCore.Components;

namespace Project.web.Components
{
    public partial class PostsManager
    {

        [Parameter]
        public List<GetPostResponse> Posts { get; set; }
        [Parameter]
        public int CountAll { get; set; }
        [Parameter]
        public int Offset { get; set; }
        [Parameter]
        public List<GetCategoryResponse> Categories { get; set; }
        [Parameter]
        public List<GetTagResponse> Tags { get; set; }
        [Parameter]
        public EventCallback<GetPostsQuery> SetSearch_Handler { get; set; }
        [Parameter]
        public EventCallback<GetPostsQuery> SetPage_Handler { get; set; }

        private async Task SetSearch_Handling(GetPostsQuery getPostQuery)
        {

            await SetSearch_Handler.InvokeAsync(getPostQuery);
        }
        private async Task SetPage_Handling(GetPostsQuery getPostQuery)
        {
            await SetPage_Handler.InvokeAsync(getPostQuery);
        }
    }
}