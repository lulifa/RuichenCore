using System;
using System.Collections.Generic;
using System.Text;

namespace RuichenCore.EFCore
{
    public class Department:EntityBase<Guid>
    {
        /// <summary>
        /// 上级部门Id
        /// </summary>
        public Guid? ParentId { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 简称
        /// </summary>
        public string ShortName { get; set; }
        /// <summary>
        /// 编号
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 部门成立日期
        /// </summary>
        public DateTime ActiveDate { get; set; }
        /// <summary>
        /// 部门解散日期，空表示未解散
        /// </summary>
        public DateTime? InactiveDate { get; set; }
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
