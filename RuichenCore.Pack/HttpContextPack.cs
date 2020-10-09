using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using RuichenCore.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace RuichenCore.Extension
{
    public static class HttpContextPack
    {
        public static void AddHttpContextServices(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUser, UserNetCore>();
        }
    }
}
