using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RuichenCore.Common;
using RuichenCore.EFCore;
using RuichenCore.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RuichenCore.Api.Controllers.Auth
{
    public class UserSettingController : ApiController
    {
        protected readonly IUserService UserService;
        protected readonly IUser CurrentUser;
        public UserSettingController(IUser user, IUserService userService)
        {
            CurrentUser = user;
            UserService = userService;
        }

        /// <summary>
        /// 合同列表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResponseResult> GetUserInfo()
        {
            User user = await UserService.GetSingle(CurrentUser.UserId);
            if (user == null)
            {
                return JsonCore(false, "用户不存在");
            }
        }
    }
}
