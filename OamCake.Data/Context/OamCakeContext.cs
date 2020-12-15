using Microsoft.EntityFrameworkCore;
using OamCake.Data.Entity;
using OamCake.Data.EntityEfConfiguration;
using System;
using System.Collections.Generic;
using System.Text;

namespace OamCake.Data.Context
{
    public class OamCakeContext : DbContext
    {
        public OamCakeContext(DbContextOptions<OamCakeContext> options) : base(options) 
        { 
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ProductEfConf());
            modelBuilder.ApplyConfiguration(new SupplyEfConf());
            modelBuilder.ApplyConfiguration(new ProductSupplyEfConf());
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Supply> Supplies { get; set; }
        public DbSet<ProductSupply> ProductSupplies { get; set; }
    }
}
