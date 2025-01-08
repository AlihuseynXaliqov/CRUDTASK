using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using DAL.Repo.Interface;

namespace DAL.Repo.Abstraction
{
    public class BlogRepository : Repository<Blog>, IBlogRepository
    {
        public BlogRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
