using RuichenCore.EFCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RuichenCore.IRepository
{
    public interface IUnitOfWork
    {
        MysqlEFCoreContext GetDbContext();

        Task<int> SaveChanges();

        void BeginTransition();

        void CommitTransition();

        void RollbackTransition();
    }
}
