using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using RuichenCore.Common;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace RuichenCore.Extension
{
    public static class SwaggerPack
    {
        private static SwaggerOptions options;
        static SwaggerPack()
        {
            options = SectionManager.GetSection<SwaggerOptions>("Ruichen", "Swagger");
        }
        public static void AddSwaggerServices(this IServiceCollection services)
        {
            string apiName = SectionManager.GetSection("Ruichen", "Name");
            services.AddSwaggerGen(c =>
            {
                options.Endpoints.ForEach(point =>
                {
                    c.SwaggerDoc(point.Version, new OpenApiInfo
                    {
                        Version = point.Version,
                        Title = $"{apiName} 接口文档-{RuntimeInformation.FrameworkDescription}",
                        Description = $"{apiName} HTTP API v1 卢立法",
                        Contact = new OpenApiContact
                        {
                            Name = "Github个人地址",
                            Email = "814570123@qq.com",
                            Url = new Uri("https://github.com/lulifa")
                        },
                        License = new OpenApiLicense
                        {
                            Name = "Gitee个人地址",
                            Url = new Uri("https://gitee.com/lulifa")
                        }
                    });
                });
                string xmlPath = Path.Combine(AppContext.BaseDirectory, "RuichenCore.Api.xml");
                c.IncludeXmlComments(xmlPath, true);
                //开启加权小锁
                c.OperationFilter<AddResponseHeadersFilter>();
                c.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();

                //在header中添加token，传递到后台中
                c.OperationFilter<SecurityRequirementsOperationFilter>();

                // Jwt Bearer认证 必须是oauth2
                c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Description = "JWT授权(数据将在请求头中进行传输) 直接在下框中输入Bearer {token}（注意两者之间是一个空格）",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });
            });
        }

        public static void UseSwaggerMid(this IApplicationBuilder app, Func<Stream> streamHtml)
        {
            if (options.Enabled)
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    string apiName = SectionManager.GetSection("Ruichen", "Name");
                    options.Endpoints.ForEach(point =>
                    {
                        c.SwaggerEndpoint(point.Url, point.Name);
                    });
                    c.RoutePrefix = options.RoutePrefix;
                    if (options.MiniProfiler)
                    {
                        c.IndexStream = streamHtml;
                    }
                    c.DefaultModelsExpandDepth(-1); //设置为 - 1 可不显示models
                    c.DocExpansion(DocExpansion.None); //设置为none可折叠所有方法
                });
            }
        }
    }

    public class SwaggerOptions
    {
        public List<SwaggerEndpoint> Endpoints { get; set; } = new List<SwaggerEndpoint>();

        public string RoutePrefix { get; set; }

        public bool MiniProfiler { get; set; } = true;

        public bool Enabled { get; set; }
    }

    public class SwaggerEndpoint
    {
        public string Name { get; set; }

        public string Version { get; set; }

        public string Url { get; set; }
    }
}
