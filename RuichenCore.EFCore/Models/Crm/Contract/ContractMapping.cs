using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace RuichenCore.EFCore
{
    public sealed class ContractMapping : IEntityTypeConfiguration<Contract>
    {
        public void Configure(EntityTypeBuilder<Contract> builder)
        {
            builder.HasKey(item => item.Id);

            builder.Property(item => item.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(item => item.MyPartyName)
                .HasMaxLength(255);

            builder.Property(item => item.CustomerName)
                .HasMaxLength(255);

            builder.Property(item => item.VendorName)
                .HasMaxLength(255);

            builder.Property(item => item.AmountNotes)
                .HasMaxLength(1000);

            builder.Property(item => item.State)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(item => item.SignatoryId)
                .HasMaxLength(50);

            builder.Property(item => item.CreatorId)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(item => item.Tag)
                .HasMaxLength(255);
        }
    }
}
