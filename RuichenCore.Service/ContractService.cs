using RuichenCore.EFCore;
using RuichenCore.IRepository;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using RuichenCore.IService;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RuichenCore.Common;

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

        public async Task<List<Contract>> GetContractList()
        {
            List<Contract> contracts = await contractRepository.Query().ToListAsync();
            return contracts;
        }
    }
}
