using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Base;
using DAL.Repo.Interface;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repo.Abstraction
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity, new()
    {
        private readonly AppDbContext dbContext;

        public Repository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public DbSet<TEntity> Table => dbContext.Set<TEntity>();

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            await Table.AddAsync(entity);
            return entity;
        }

        public void Delete(TEntity entity)
        {
            entity.IsDeleted = true;
            Table.Update(entity);
        }

        public IQueryable<TEntity> GetAll()
        {
            return Table.Where(x => !x.IsDeleted);
        }

        public async Task<TEntity> GetById(int Id)
        {
            return await Table.AsNoTracking().FirstOrDefaultAsync(x => x.Id == Id && !x.IsDeleted);
        }

        public async Task<bool> IsExist(Expression<Func<TEntity, bool>> expression)
        {
            return await Table.AsNoTracking().AnyAsync(expression);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await dbContext.SaveChangesAsync();
        }

        public void Update(TEntity entity)
        {
            Table.Update(entity);
        }
    }
}
