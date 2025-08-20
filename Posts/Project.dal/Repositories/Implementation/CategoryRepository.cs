using Project.dal.Generic;
using Project.dal.Models;
using Project.dal.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace Project.dal.Repositories.Implementation
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(DbContext context) : base(context)
        {
        }
    }
}
