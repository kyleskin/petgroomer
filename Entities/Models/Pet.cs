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

		[Required(ErrorMessage = "Pet type is required.")]
		public PetTypes Type { get; set; }

		[ForeignKey(nameof(Owner))]
		public Guid OwnerId { get; set; }
	}
}

