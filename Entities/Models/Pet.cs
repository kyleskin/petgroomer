using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
	public class Pet
	{
		[Column("PetId")]
		public Guid Id { get; set; }

		[Required(ErrorMessage = "Pet name is required.")]
		public string? Name { get; set; }

		public string? Notes { get; set; }

		ICollection<Appointment>? Appointments { get; set; }

		[ForeignKey(nameof(PetType))]
		public Guid PetTypeId { get; set; }
		public PetType? PetType { get; set; }

		[ForeignKey(nameof(Owner))]
		public Guid OwnerId { get; set; }
	}
}

