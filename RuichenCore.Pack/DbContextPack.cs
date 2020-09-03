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
            services.AddDbContext<RuichenContext>(options =>
            {
                options.UseMySql(SectionManager.GetSection("Ruichen", "DbContext", "MySql","ConnectionString"));
            });
        }
    }
}
