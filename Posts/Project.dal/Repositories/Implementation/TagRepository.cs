using Project.dal.Generic;
using Project.dal.Models;
using Project.dal.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace Project.dal.Repositories.Implementation
{
    public class TagRepository : GenericRepository<Tag>, ITagRepository
    {
        public TagRepository(DbContext context) : base(context)
        {
        }
    }
}
