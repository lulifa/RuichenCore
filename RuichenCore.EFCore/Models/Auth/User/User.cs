using System;
using System.Collections.Generic;
using System.Text;

namespace RuichenCore.EFCore
{
    public class User : EntityBase<string>
    {
        /// <summary>
        /// 所属法人Id
        /// </summary>
        public Guid? CompanyId { get; set; }
        /// <summary>
        /// 所属部门Id
        /// </summary>
        public Guid? DepartmentId { get; set; }
        /// <summary>
        /// 直接上级Id
        /// </summary>
        public string ParentId { get; set; }
        /// <summary>
        /// 审批上级Id
        /// </summary>
        public string ApproveLeaderId { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 编号
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 职位
        /// </summary>
        public string Position { get; set; }
        /// <summary>
        /// 性别（0:男;1:女）
        /// </summary>
        public Gender? Gender { get; set; }
        /// <summary>
        /// 身份证号码
        /// </summary>
        public string IdentityCard { get; set; }
        /// <summary>
        /// 工作地点
        /// </summary>
        public string Location { get; set; }
        /// <summary>
        /// 级别
        /// </summary>
        public string Grade { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Mail { get; set; }
        /// <summary>
        /// 手机号码
        /// </summary>
        public string Mobile { get; set; }
        /// <summary>
        /// 固话号码
        /// </summary>
        public string Telephone { get; set; }
        /// <summary>
        /// 银行卡号
        /// </summary>
        public string BankCard { get; set; }
        /// <summary>
        /// 微信号码
        /// </summary>
        public string WeChat { get; set; }
        /// <summary>
        /// 钉钉号码
        /// </summary>
        public string DingTalk { get; set; }
        /// <summary>
        /// 工作性质
        /// </summary>
        public string JobNature { get; set; }
        /// <summary>
        /// 登录权限
        /// </summary>
        public LoginModes LoginModes { get; set; }
        /// <summary>
        /// 入职日期
        /// </summary>
        public DateTime ActiveDate { get; set; }
        /// <summary>
        /// 离职日期，为空表示在职
        /// </summary>
        public DateTime? InactiveDate { get; set; }
        public string OtherInfos { get; set; }
    }
    public enum Gender
    {
        Male = 0,
        Female = 1
    }
    public enum LoginModes
    {
        None = 0,
        PC = 1,
        Mobile = 2
    }
}
