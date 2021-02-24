using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RuichenCore.EFCore;
using RuichenCore.IRepository;
using RuichenCore.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RuichenCore.Service
{
    public class ContractService : IContractService
    {
        private readonly IServiceProvider provider;
        public ContractService(IServiceProvider serviceProvider)
        {
            provider = serviceProvider;
        }

        protected IBaseRepository<Contract> contractRepository => provider.GetService<IBaseRepository<Contract>>();

        public async Task<List<Contract>> GetList()
        {
            List<Contract> contracts = await contractRepository.Query().ToListAsync();
            return contracts;
        }
        public IQueryable<Contract> Query()
        {
            IQueryable<Contract> query = contractRepository.Query();
            return query;
        }
    }
}
