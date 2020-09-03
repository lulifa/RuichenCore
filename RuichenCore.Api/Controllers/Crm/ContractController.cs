using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RuichenCore.Common;
using RuichenCore.EFCore;
using RuichenCore.IService;

namespace RuichenCore.Api.Controllers
{
    [Description("商务管理-合同")]
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
            List<Contract> contracts = await ContractService.GetContractList();
            return JsonCore(true, contracts);
        }
    }
}
