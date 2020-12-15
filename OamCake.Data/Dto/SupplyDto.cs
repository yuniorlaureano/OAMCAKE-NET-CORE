using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OamCake.Data.Dto
{
    public class SupplyDto
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "El nombre es requirido")]
        public string Name { get; set; }
        [Required(ErrorMessage = "La descripción es requerida")]
        public string Description { get; set; }
    }
}
