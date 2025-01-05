using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using DAL.Repo.Interface;

namespace DAL.Repo.Abstraction
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {


        public CategoryRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
