using Project.contract.Services;
using Project.core.Queries.GetPost;
using Microsoft.AspNetCore.Components;

namespace Project.web.Pages
{
    public partial class EditPost
    {
        private bool _isLoading;
        private GetPostResponse _post;

        [Parameter]
        public int Id { get; set; }

        [Inject]
        public IPostService PostService { get; set; }


        protected override async Task OnInitializedAsync()
        {
            _isLoading = true;
            _post = await PostService.GetPost(new GetPostQuery() { Id = Id }).ExecuteAsync<GetPostResponse>();
            _isLoading = false;
        }
    }
}