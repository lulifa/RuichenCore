using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RuichenCore.Common;
using RuichenCore.EFCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace RuichenCore.Extension
{
    public static class DbContextPack
    {
        public static void AddDbContextService(this IServiceCollection services)
        {
            // 以后用autofac批量注入
            services.AddDbContext<CrmContext>();

        }
    }
}
