using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace RuichenCore.EFCore
{
    public class RuichenContext:DbContext
    {
        public RuichenContext(DbContextOptions<RuichenContext> dbContextOptions):base(dbContextOptions)
        {

        }

        public DbSet<Contract> Contracts { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
