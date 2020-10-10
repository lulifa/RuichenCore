using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace RuichenCore.Common
{
    public static class SectionManager
    {
        private static IConfiguration config => GetConfiguration();
        public static string ConnectionString => GetConnectionString();

        /// <summary>
        /// 这种方式，可以直接读目录里的json文件，而不是 bin 文件夹下的，所以不用修改复制属性
        /// </summary>
        private static IConfiguration GetConfiguration()
        {
            string contentPath = $"appsettings.json";
            IConfiguration config = new ConfigurationBuilder()
               .Add(new JsonConfigurationSource { Path = contentPath, Optional = false, ReloadOnChange = true })
               .Build();
            return config;
        }

        private static string GetConnectionString()
        {
            string conn = GetSection("Ruichen", "DbContext", "MySql", "ConnectionString");
            return conn;
        }

        ///// <summary>
        ///// 这种方式，读bin文件夹下的，所以要将文件设置为始终复制,微软源码就是这样的写的
        ///// </summary>
        //private static void GetConfiguration()
        //{
        //    configuration = new ConfigurationBuilder()
        //            .SetBasePath(AppContext.BaseDirectory)
        //            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        //            .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true)
        //            .Build();
        //}

        /// <summary>
        /// 获取某个值
        /// </summary>
        /// <param name="sections"></param>
        /// <returns></returns>
        public static string GetSection(params string[] sections)
        {
            return config[string.Join(":", sections)];
        }

        /// <summary>
        /// 将Json结构绑定为对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sections"></param>
        /// <returns></returns>
        public static T GetSection<T>(params string[] sections)
        {
            return config.GetSection(string.Join(":", sections)).Get<T>();
        }
    }
}
