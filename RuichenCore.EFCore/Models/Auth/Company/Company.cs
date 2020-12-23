using System;
using System.Collections.Generic;
using System.Text;

namespace RuichenCore.EFCore
{
    public class Company : EntityBase<Guid>
    {
        /// <summary>
        /// 公司名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 公司简称
        /// </summary>
        public string ShortName { get; set; }
        /// <summary>
        /// 编号
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 同步id
        /// </summary>
        public string SyncId { get; set; }
        /// <summary>
        /// 排序字段
        /// </summary>
        public int Order { get; set; }
        public string OtherInfos { get; set; }
    }
}
