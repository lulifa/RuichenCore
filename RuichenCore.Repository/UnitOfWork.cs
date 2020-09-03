using RuichenCore.EFCore;
using RuichenCore.IRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RuichenCore.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RuichenContext context;
        public UnitOfWork(RuichenContext ruichenContext)
        {
            context = ruichenContext;
        }
        public RuichenContext GetDbContext()
        {
            return context;
        }
        public async Task<int> SaveChanges()
        {
            return await context.SaveChangesAsync();
        }
        public void BeginTransition()
        {
            context.Database.BeginTransactionAsync();
        }

        public void CommitTransition()
        {
            context.Database.CommitTransaction();
        }
        public void RollbackTransition()
        {
            context.Database.RollbackTransaction();
        }
    }
}
