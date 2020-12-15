using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OamCake.Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace OamCake.Data.EntityEfConfiguration
{
    public class ProductSupplyEfConf : IEntityTypeConfiguration<ProductSupply>
    {

        public void Configure(EntityTypeBuilder<ProductSupply> builder)
        {
            builder.ToTable("ProductSupply");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).IsRequired();
        }

    }
}
