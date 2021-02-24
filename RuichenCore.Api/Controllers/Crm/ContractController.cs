using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RuichenCore.Common;
using RuichenCore.EFCore;
using RuichenCore.IService;
using StackExchange.Profiling;

namespace RuichenCore.Api.Controllers
{
    /// <summary>
    /// 商务模块
    /// </summary>
    public class ContractController : ApiController
    {
        protected readonly IContractService ContractService;
        protected readonly IUser CurrentUser;
        public ContractController(IContractService contractService,IUser user)
        {
            ContractService = contractService;
            CurrentUser = user;
        }

        /// <summary>
        /// 合同列表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResponseResult> GetPagedList()
        {
            IQueryable<Contract> query = ContractService.Query();
            int count = query.Count();
            List<Contract> contracts = await query.ToListAsync();
            List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
            list.AddRange(contracts.Select(item => SelectContract(item)));
            return JsonCore(true, contracts.ToJsonPaged(count));
        }
        private static Dictionary<string,object> SelectContract(Contract model)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict["id"] = model.Id;
            dict["name"] = model.Name;
            dict["amount"] = model.Amount;
            return dict;
        }
    }
}
