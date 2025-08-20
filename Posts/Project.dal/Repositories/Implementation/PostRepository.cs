using Project.common;
using Project.dal.Generic;
using Project.dal.Models;
using Project.dal.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace Project.dal.Repositories.Implementation
{
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        public PostRepository(DbContext context) : base(context)
        {
        }

        public async Task<WithCount<Post>> GetPosts(List<int>? tagIds, string? userId, int categoryId, int offset, int limit)
        {
            var query = _dbSet
                .Include(x => x.Category)
                .Include(x => x.Tags)
                .Include(x => x.Comments)
                .AsQueryable();

            if (tagIds != null && tagIds.Count > 0)
            {
                query = query.Where(post => post.Tags.Any(tag => tagIds.Contains(tag.Id)));
            }

            if (!string.IsNullOrEmpty(userId))
            {
                query = query.Where(post => post.UserId == userId);
            }

            if (categoryId > 0)
            {
                query = query.Where(post => post.CategoryId == categoryId);
            }

            var response = await query.Skip(offset * limit).Take(limit).ToListAsync();
            var count = await query.CountAsync();
            return new WithCount<Post>() { Count = count, Response = response };
        }

        public async Task<Post> GetPostWithDetails(int Id)
        {
            return await _dbSet
                .Include(x => x.Category)
                .Include(x => x.Tags)
                .Include(x => x.Comments)
                .FirstOrDefaultAsync(x => x.Id == Id);
        }
    }
}
