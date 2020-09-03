using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RuichenCore.IRepository
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<int> Add(TEntity entity);

        Task<int> Add(IEnumerable<TEntity> entities);

        Task<int> Remove(TEntity entity);

        Task<int> Remove(IEnumerable<TEntity> entities);

        Task<int> Update(TEntity entity);

        Task<int> Update(IEnumerable<TEntity> entities);

        Task<TEntity> Find(object id);

        IQueryable<TEntity> Query();

        IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> expression);
    }
}
