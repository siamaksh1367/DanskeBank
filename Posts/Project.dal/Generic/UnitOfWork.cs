using Project.dal.Models;
using Project.dal.Repositories.Implementation;
using Project.dal.Repositories.Interface;

namespace Project.dal.Generic
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProjectDB _context;


        public IPostRepository Posts { get; private set; }
        public ICommentRepository Comments { get; private set; }
        public ITagRepository Tags { get; private set; }
        public ICategoryRepository Categories { get; private set; }

        public UnitOfWork(ProjectDB context)
        {
            _context = context;
            Posts = new PostRepository(_context);
            Comments = new CommentRepository(_context);
            Tags = new TagRepository(_context);
            Categories = new CategoryRepository(_context);
        }


        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
