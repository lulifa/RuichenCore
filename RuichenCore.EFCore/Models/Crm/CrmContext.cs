using Microsoft.EntityFrameworkCore;
using RuichenCore.Common;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace RuichenCore.EFCore
{
    public class CrmContext:RuichenDbContext
    {
        public CrmContext(DbContextOptions<CrmContext> dbContextOptions):base(dbContextOptions)
        {

        }

        public DbSet<Contract> Contracts { get; set; }
    }
}
