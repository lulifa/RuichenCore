using Autofac;
using RuichenCore.EFCore;
using RuichenCore.IRepository;
using RuichenCore.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace RuichenCore.Extension
{
    public class AutoFacPack : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(BaseRepository<>)).As(typeof(IBaseRepository<>));
            string basePath = AppContext.BaseDirectory;
            string servicePath = Path.Combine(basePath, "RuichenCore.Service.dll");
            string repositoryPath = Path.Combine(basePath, "RuichenCore.Repository.dll");
            Assembly assemblyService = Assembly.LoadFrom(servicePath);
            Assembly assemblyRepository = Assembly.LoadFrom(repositoryPath);
            builder.RegisterAssemblyTypes(assemblyService)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(assemblyRepository)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
