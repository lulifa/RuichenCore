using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RuichenCore.EFCore
{
    public sealed class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(item => item.Id);

            builder.Property(item => item.ParentId)
                .HasMaxLength(50);
            builder.Property(item => item.ApproveLeaderId)
                .HasMaxLength(50);
            builder.Property(item => item.Password)
                .IsRequired()
                .HasMaxLength(128);
            builder.Property(item => item.Name)
                .IsRequired()
                .HasMaxLength(128);
            builder.Property(item => item.Code)
                .HasMaxLength(128);
            builder.Property(item => item.Position)
                .HasMaxLength(128);
            builder.Property(item => item.IdentityCard)
                .HasMaxLength(128);
            builder.Property(item => item.Location)
                .HasMaxLength(128);
            builder.Property(item => item.Grade)
                .HasMaxLength(128);
            builder.Property(item => item.Mail)
                .HasMaxLength(128);
            builder.Property(item => item.Mobile)
                .HasMaxLength(128);
            builder.Property(item => item.Telephone)
                .HasMaxLength(128);
            builder.Property(item => item.BankCard)
                .HasMaxLength(128);
            builder.Property(item => item.WeChat)
                .HasMaxLength(128);
            builder.Property(item => item.DingTalk)
                .HasMaxLength(128);
            builder.Property(item => item.JobNature)
                .HasMaxLength(128);
        }
    }
}
