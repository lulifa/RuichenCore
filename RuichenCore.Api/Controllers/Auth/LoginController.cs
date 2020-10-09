using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RuichenCore.Common;

namespace RuichenCore.Api.Controllers
{
    /// <summary>
    /// 登录模块
    /// </summary>
    [AllowAnonymous]
    public class LoginController : ApiController
    {

        /// <summary>
        /// 获取字符串
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ResponseResult GetJwtStr([FromBody] LoginModel model)
        {
            string[] userIds = new string[] { "admin" };
            List<string> ids = userIds.ToList();
            if (!ids.Contains(model.name))
            {
                return JsonCore(false, "用户名和密码不正确");
            }
            TokenModelJwt tokenModelJwt = new TokenModelJwt();
            tokenModelJwt.UserId = model.name;
            tokenModelJwt.UserName = model.name;
            tokenModelJwt.Role = "Admin,User";
            TokenShowModel info = BearJwtManager.BuildJwtToken(tokenModelJwt);
            return JsonCore(true, info);
        }

    }

    public class LoginModel
    {
        public string name { get; set; }
    }
}
