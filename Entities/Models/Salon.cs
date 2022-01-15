using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Salon
    {
        [Column("SalonId")]
        public Guid Id { get; set; }
        
        [Required(ErrorMessage = "Salon name is required.")]
        public string? Name { get; set; }

        public ICollection<Groomer>? Groomers { get; set; }
    }
}