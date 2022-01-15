using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
	public class Owner
	{
		[Column("OwnerId")]
		public Guid Id { get; set; }

		[Required(ErrorMessage = "Owner first name is required.")]
		[MaxLength(60, ErrorMessage = "Maximum length for owner first name is 60 characters.")]
		public string? FirstName { get; set; }

		[Required(ErrorMessage = "Owner last name is required.")]
		[MaxLength(60, ErrorMessage = "Maximum length for owner last name is 60 characters.")]
		public string? LastName { get; set; }

		public string? Email { get; set; }

		[Required(ErrorMessage = "Owner phone number is required.")]
		public string? Phone { get; set; }

		[ForeignKey(nameof(Salon))]	
		public Guid SalonId { get; set; }

		public ICollection<Pet>? Pets { get; set; }
		
	}
}

