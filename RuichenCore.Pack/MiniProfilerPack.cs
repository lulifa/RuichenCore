using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace RuichenCore.Extension
{
    public static class MiniProfilerPack
    {
        public static void AddMiniProfilerService(this IServiceCollection services)
        {
            services.AddMiniProfiler(options =>
            {
                options.RouteBasePath = "/profiler";
                options.PopupRenderPosition = StackExchange.Profiling.RenderPosition.Left;
                options.PopupShowTimeWithChildren = true;
            }).AddEntityFramework();
        }

        public static void UseMiniProfilerMid(this IApplicationBuilder app)
        {
            app.UseMiniProfiler();
        }
    }
}
