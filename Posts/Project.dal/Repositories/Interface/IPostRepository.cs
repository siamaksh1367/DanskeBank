using Project.common;
using Project.dal.Generic;
using Project.dal.Models;

namespace Project.dal.Repositories.Interface
{
    public interface IPostRepository : IGenericRepository<Post>
    {
        Task<WithCount<Post>> GetPosts(List<int>? tagIds, string? userId, int categoryId, int offset, int limit);
        Task<Post> GetPostWithDetails(int Id);
    }

}
