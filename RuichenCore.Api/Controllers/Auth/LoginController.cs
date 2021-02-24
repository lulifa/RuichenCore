using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RuichenCore.Common;
using RuichenCore.EFCore;
using RuichenCore.IService;
using Utility.Core;

namespace RuichenCore.Api.Controllers
{
    /// <summary>
    /// 登录模块
    /// </summary>
    [AllowAnonymous]
    public class LoginController : ApiController
    {
        protected readonly IUserService UserService;
        public LoginController(IUserService userService)
        {
            UserService = userService;
        }

        /// <summary>
        /// 登录方法
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResponseResult> Login([FromBody] LoginModel model)
        {
            if (string.IsNullOrEmpty(model.Name) || string.IsNullOrEmpty(model.Password))
            {
                return JsonCore(false, "用户名和密码不能为空");
            }
            User user = await UserService.GetSingle(model.Name);
            if (user == null)
            {
                return JsonCore(false, "用户不存在");
            }
            string password = CryptoHelper.EncryptAes(model.Password);
            if (user.Password != password)
            {
                return JsonCore(false, "密码错误");
            }
            return TokenFormat(user);
        }

        private ResponseResult TokenFormat(User user)
        {
            bool isAdmin = false;
            string token = BearJwtManager.BuildJwtToken(user.Id, isAdmin);
            TokenModel tokenModel = BearJwtManager.SerializeJwtToken(token);
            return JsonCore(true, new
            {
                token,
                user = new
                {
                    user.Id,
                    user.Name
                },
                expireAt = tokenModel.ExpireAt,
                role = tokenModel.Role
            });
        }

    }

    public class LoginModel
    {
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
