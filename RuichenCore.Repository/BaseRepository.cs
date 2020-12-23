using RuichenCore.EFCore;
using RuichenCore.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RuichenCore.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : class
    {
        private IUnitOfWork baseUnitOfWork;
        private MysqlEFCoreContext ruichenContext;


        public BaseRepository(IUnitOfWork unitOfWork)
        {
            baseUnitOfWork = unitOfWork;
            ruichenContext = baseUnitOfWork.GetDbContext();
        }
        public async Task<int> Add(TEntity entity)
        {
            ruichenContext.Add(entity);
            return await baseUnitOfWork.SaveChanges();
        }

        public async Task<int> Add(IEnumerable<TEntity> entities)
        {
            ruichenContext.AddRange(entities);
            return await baseUnitOfWork.SaveChanges();
        }

        public async Task<int> Remove(TEntity entity)
        {
            ruichenContext.Remove(entity);
            return await baseUnitOfWork.SaveChanges();
        }

        public async Task<int> Remove(IEnumerable<TEntity> entities)
        {
            ruichenContext.RemoveRange(entities);
            return await baseUnitOfWork.SaveChanges();
        }

        public async Task<int> Update(TEntity entity)
        {
            ruichenContext.Update(entity);
            return await baseUnitOfWork.SaveChanges();
        }

        public async Task<int> Update(IEnumerable<TEntity> entities)
        {
            ruichenContext.UpdateRange(entities);
            return await baseUnitOfWork.SaveChanges();
        }

        public async Task<TEntity> Find(object id)
        {
            return await ruichenContext.Set<TEntity>().FindAsync(id);
        }

        public IQueryable<TEntity> Query()
        {
            return ruichenContext.Set<TEntity>();
        }

        public IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> expression)
        {
            return ruichenContext.Set<TEntity>().Where(expression);
        }
    }
}
