using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
	public class PetType
	{
		[Column("PetTypeId")]
		public Guid Id { get; set; }

		[Required(ErrorMessage = "Type is required.")]
		public string? Type { get; set; }
	}
}

