using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace OamCake.Data.Entity
{
    public class Product
    {
        public Guid Id { get; set; } = new Guid();
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }

        public IEnumerable<ProductSupply> ProductSupplies { get; set; }
    }
}
