using System;
using System.Collections.Generic;
using System.Text;

namespace OamCake.Data.Entity
{
    public class ProductSupply
    {
        public Guid Id { get; set; } = new Guid();
        public Guid ProductId { get; set; }
        public Guid SupplyId { get; set; }
        public float Quantity { get; set; }
        public string MeasurementUnit { get; set; }
        public string Detail { get; set; }
        public bool IsForProjection { get; set; }

        public Product Product { get; set; }
        public Supply Supply { get; set; }
    }
}
