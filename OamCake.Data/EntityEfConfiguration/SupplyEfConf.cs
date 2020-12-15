using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OamCake.Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace OamCake.Data.EntityEfConfiguration
{
    public class SupplyEfConf : IEntityTypeConfiguration<Supply>
    {

        public void Configure(EntityTypeBuilder<Supply> builder)
        {
            builder.ToTable("Supply");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.Description).IsRequired();

            builder.HasMany(p => p.ProductSupplies)
                   .WithOne(p => p.Supply)
                   .HasForeignKey(p => p.SupplyId);
        }

    }
}
