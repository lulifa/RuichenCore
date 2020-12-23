using Microsoft.EntityFrameworkCore;
using RuichenCore.Common;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace RuichenCore.EFCore
{
    public class MysqlEFCoreContext:RuichenDbContext
    {
        public MysqlEFCoreContext(DbContextOptions<MysqlEFCoreContext> dbContextOptions):base(dbContextOptions)
        {

        }


        public DbSet<User> Users { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Company> Companies { get; set; }

        public DbSet<Contract> Contracts { get; set; }

    }
}
