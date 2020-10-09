using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using RuichenCore.Common;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace RuichenCore.Extension
{
    public static class AuthorizationPack
    {
        public static void AddAuthorizationServices(this IServiceCollection services)
        {
            // 自定义复杂授权策略 以后再搞
        }
    }
}
