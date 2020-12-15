using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;
using System.Text;

namespace OamCake.Data.Entity
{
    public class Supply
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required(ErrorMessage = "El nombre es requirido")]
        public string Name { get; set; }
        [Required(ErrorMessage = "La descripción es requerida")]
        public string Description { get; set; }

        public IEnumerable<ProductSupply> ProductSupplies { get; set; }
    }
}
