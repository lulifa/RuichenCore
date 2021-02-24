using RuichenCore.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuichenCore.IService
{
    public interface IContractService
    {
        Task<List<Contract>> GetList();
        IQueryable<Contract> Query();
    }
}
