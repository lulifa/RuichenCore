using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RuichenCore.Common;
using RuichenCore.EFCore;
using RuichenCore.IService;
using StackExchange.Profiling;

namespace RuichenCore.Api.Controllers
{
    /// <summary>
    /// 商务模块
    /// </summary>
    [AllowAnonymous]
    public class ContractController : ApiController
    {
        protected readonly IContractService ContractService;
        public ContractController(IContractService contractService)
        {
            ContractService = contractService;
        }

        /// <summary>
        /// 合同列表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResponseResult> GetPagedList()
        {
            using (MiniProfiler.Current.Step("立法试试"))
            {
                List<Contract> contracts = await ContractService.GetContractList();
                return JsonCore(true, contracts.ToJsonPaged(contracts.Count));
            }
        }
    }
}
