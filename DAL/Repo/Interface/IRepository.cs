using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repo.Interface
{
    public interface IRepository<TEntity> where TEntity : BaseEntity, new ()
    {
        DbSet<TEntity> Table { get; }

        Task<TEntity> GetById(int id);
        IQueryable<TEntity> GetAll();
        Task<TEntity> CreateAsync(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        Task<int> SaveChangesAsync();

        Task<bool> IsExist(Expression<Func<TEntity, bool>> expression);

    }
}
