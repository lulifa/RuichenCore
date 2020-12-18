using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RuichenCore.Common;

namespace RuichenCore.Api.Controllers.Auth
{
    public class MenuController : ApiController
    {
        protected readonly IUser CurrentUser;
        public MenuController(IUser user)
        {
            var test = this.User.Identity.Name;
            CurrentUser = user;
        }

        [HttpGet]
        public ResponseResult GetRoutesConfig()
        {
           List<Menu> menus= MenuManager.GetMenus();
            return JsonCore(true,menus);
        }
    }
}
