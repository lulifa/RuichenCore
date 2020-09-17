using Microsoft.EntityFrameworkCore;
using RuichenCore.Common;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace RuichenCore.EFCore
{
    public abstract class RuichenDbContext:DbContext
    {
        public RuichenDbContext(DbContextOptions dbContextOptions):base(dbContextOptions)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseMySql(SectionManager.ConnectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
