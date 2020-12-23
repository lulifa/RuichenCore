using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RuichenCore.EFCore
{
    public sealed class CompanyMapping : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(item => item.Id);

            builder.Property(item => item.Name)
                .IsRequired()
                .HasMaxLength(128);
            builder.Property(item => item.ShortName)
                .HasMaxLength(128);
            builder.Property(item => item.Code)
                .HasMaxLength(128);
            builder.Property(item => item.SyncId)
                .HasMaxLength(128);
        }
    }
}
