using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RuichenCore.Common;
using RuichenCore.EFCore;
using RuichenCore.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utility.Core;

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
        /// 用户信息
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
            return JsonCore(true, new
            {
                user.Id,
                user.Name,
                user.Mail,
                user.Mobile,
                user.Position
            });
        }
        [HttpPost]
        public async Task<ResponseResult> SaveUserInfo(SaveUserInfoParam param)
        {
            User user = await UserService.GetSingle(CurrentUser.UserId);
            if (user == null)
            {
                return JsonCore(false, "用户不存在");
            }
            user.Name = param.Name;
            user.Mail = param.Mail;
            user.Mobile = param.Mobile;
            user.Position = param.Position;
            await UserService.Update(user);
            return JsonCore(true);
        }

        /// <summary>
        /// 密码设置
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResponseResult> GetUserPassword()
        {
            User user = await UserService.GetSingle(CurrentUser.UserId);
            if (user == null)
            {
                return JsonCore(false, "用户不存在");
            }
            string password = CryptoHelper.DecryptAes(user.Password);
            return JsonCore(true, new
            {
                password
            });
        }

        [HttpPost]
        public async Task<ResponseResult> SaveUserPassword(SaveUserPasswordParam param)
        {
            User user = await UserService.GetSingle(CurrentUser.UserId);
            if (user == null)
            {
                return JsonCore(false, "用户不存在");
            }
            string encryOldPWd = CryptoHelper.EncryptAes(param.OldPWD);
            string encryNewPWD = CryptoHelper.EncryptAes(param.NewPWD);
            if (user.Password != encryOldPWd)
            {
                return JsonCore(false, "原密码错误");
            }
            if (user.Password == encryNewPWD)
            {
                return JsonCore(false, "新密码与原密码不能相同");
            }
            user.Password = encryNewPWD;
            await UserService.Update(user);
            return JsonCore(true);
        }
    }

    public class SaveUserInfoParam
    {
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Mobile { get; set; }
        public string Position { get; set; }
    }

    public class SaveUserPasswordParam
    {
        public string OldPWD { get; set; }
        public string NewPWD { get; set; }
    }
}
