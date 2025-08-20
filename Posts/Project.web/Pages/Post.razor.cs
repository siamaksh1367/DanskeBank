using Project.contract.Services;
using Project.core.Commands.CreateComment;
using Project.core.Queries.GetComments;
using Project.core.Queries.GetPost;
using Microsoft.AspNetCore.Components;

namespace Project.web.Pages
{
    public partial class Post
    {
        private bool _isLoading;
        private GetPostResponse _post;
        private List<GetCommentResponse> _commentt;

        [Parameter]
        public int Id { get; set; }

        [Inject]
        public IPostService PostService { get; set; }

        [Inject]
        public ICommentService CommentService { get; set; }


        protected override async Task OnInitializedAsync()
        {
            _isLoading = true;
            _post = await PostService.GetPost(new GetPostQuery() { Id = Id }).ExecuteAsync<GetPostResponse>();
            _commentt = await CommentService.GetCommentsForPost(new GetCommentsQuery() { PostId = _post.Id }).ExecuteAsync<List<GetCommentResponse>>();
            _isLoading = false;
        }

        public async Task CreateComment_handling(CreateCommentCommand createCommentCommand)
        {
            var addedComment = await CommentService.CreateComment(createCommentCommand).ExecuteAsync<GetCommentResponse>();
            _commentt.Add(addedComment);
            StateHasChanged();

        }
    }
}