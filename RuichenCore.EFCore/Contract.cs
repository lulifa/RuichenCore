using System;
using System.ComponentModel;

namespace RuichenCore.EFCore
{
    public class Contract : EntityBase<Guid>
    {
        public Guid? ParentId { get; set; }

        public Guid CategoryId { get; set; }

        public Guid DepartmentId { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }

        /// <summary>我方类型。</summary>
        public PartyType MyPartyType { get; set; }

        public string MyPartyName { get; set; }

        public Guid? CustomerId { get; set; }

        public string CustomerName { get; set; }

        public Guid? VendorId { get; set; }

        public string VendorName { get; set; }

        public decimal Amount { get; set; }

        public string AmountNotes { get; set; }

        public DateTime? FreeMaintenanceDueDate { get; set; }

        public decimal? AnnualMaintenanceFee { get; set; }

        public decimal? PerformanceBond { get; set; }

        public string State { get; set; }

        public string SignatoryId { get; set; }

        public DateTime? SignTime { get; set; }

        public DateTime? PlanInspectDate { get; set; }

        public DateTime? ActualInspectDate { get; set; }

        public string CreatorId { get; set; }

        public DateTime CreateTime { get; set; }

        public string Tag { get; set; }
    }

    public enum PartyType
    {
        甲方 = 0,
        乙方 = 1,
    }
}
