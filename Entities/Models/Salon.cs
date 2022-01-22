using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Salon
    {
        [Column("SalonId")]
        public Guid Id { get; set; }
        
        [Required(ErrorMessage = "Salon name is required.")]
        public string? Name { get; set; }

        public ICollection<Groomer>? Groomers { get; set; }
        public ICollection<Owner>? Owners { get; set; }
    }
}