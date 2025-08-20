using Project.dal.Generic;
using Project.dal.Models;
using Project.dal.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace Project.dal.Repositories.Implementation
{
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        public CommentRepository(DbContext context) : base(context)
        {
        }
    }
}
