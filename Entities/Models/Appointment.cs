using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
	public class Appointment
	{
		[Column("AppointmentId")]
		public Guid Id { get; set; }

		[Required(ErrorMessage = "Appointment date & time is required.")]
		public DateTime DateTime { get; set; }

		public int Duration { get; set; }

		public string? Details { get; set; }

		[ForeignKey(nameof(Pet))]
		public Guid PetId { get; set; }
		public Pet? Pet { get; set; }
	}
}

