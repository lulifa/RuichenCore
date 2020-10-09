using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace RuichenCore.Common
{
    public class UserNetCore : IUser
    {
        private readonly IHttpContextAccessor accessor;

        public UserNetCore(IHttpContextAccessor httpContextAccessor)
        {
            accessor = httpContextAccessor;
        }
        public string UserId => GetUserId();

        private string GetUserId()
        {
            return accessor.HttpContext.User.Identity.Name;
        }

        public string Token => GetToken();

        private string GetToken()
        {
            return accessor.HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
        }
    }
}
