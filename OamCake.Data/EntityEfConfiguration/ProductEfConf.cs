using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OamCake.Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace OamCake.Data.EntityEfConfiguration
{
    public class ProductEfConf : IEntityTypeConfiguration<Product>
    {

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.Description).IsRequired();
            builder.Property(p => p.Price).IsRequired();

            builder.HasMany(p => p.ProductSupplies)
                   .WithOne(p => p.Product)
                   .HasForeignKey(p => p.ProductId);
        }

    }
}
