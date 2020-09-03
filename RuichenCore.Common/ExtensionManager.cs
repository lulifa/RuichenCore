using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RuichenCore.Common
{
    public static class ExtensionManager
    {
        public static PageResult<T> ToJsonPaged<T>(this IEnumerable<T> sources,int? total)
        {
           return new PageResult<T>(sources, total);
        }

        public static IQueryable<T> ToPaged<T>(this IQueryable<T> sources,PageRequestParam param)
        {
            return PageResult<T>.ToPaged(sources, param.PageIndex, param.PageSize);
        }

        public static IEnumerable<T> ToPaged<T>(this IEnumerable<T> sources, PageRequestParam param)
        {
            return PageResult<T>.ToPaged(sources, param.PageIndex, param.PageSize);
        }
    }
}
