using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RuichenCore.EFCore
{
    public sealed class DepartmentMapping : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(item => item.Id);

            builder.Property(item => item.ParentId)
                .HasMaxLength(50);
            builder.Property(item => item.Name)
                .IsRequired()
                .HasMaxLength(128);
            builder.Property(item => item.ShortName)
                .HasMaxLength(128);
            builder.Property(item => item.Code)
                .HasMaxLength(128);
            builder.Property(item => item.Type)
                .HasMaxLength(128);
            builder.Property(item => item.SyncId)
                .HasMaxLength(128);
        }
    }
}
