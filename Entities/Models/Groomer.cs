using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Groomer
    {
        [Column("GroomerId")]
        public Guid Id { get; set; }
        
        [Required(ErrorMessage = "Groomer First Name is required.")]
        public string? FirstName { get; set; }
        
        [Required(ErrorMessage = "Groomer Last Name is required.")]
        public string? LastName { get; set;}

        public ICollection<Appointment>? Appointments { get; set; }

        [ForeignKey(nameof(Salon))]
        public Guid SalonId { get; set; }
    }
}