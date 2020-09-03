using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuichenCore.Common
{
    /// <summary>
    /// 数据分页类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PageResult<T>
    {
        public int Total { get; set; }

        public IEnumerable<T> Rows { get; set; }

        public PageResult(IEnumerable<T> sources, int? total)
        {
            Total = total ?? sources.Count();
            Rows = sources;
        }

        public static IQueryable<T> ToPaged(IQueryable<T> sources, int pageIndex, int pageSize)
        {
            pageIndex = pageIndex <= 0 ? 1 : pageIndex;
            pageSize = pageSize <= 0 ? 10 : pageSize;
            sources = sources.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return sources;
        }

        public static IEnumerable<T> ToPaged(IEnumerable<T> sources, int pageIndex, int pageSize)
        {
            pageIndex = pageIndex <= 0 ? 1 : pageIndex;
            pageSize = pageSize <= 0 ? 10 : pageSize;
            sources = sources.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return sources;
        }
    }
}
