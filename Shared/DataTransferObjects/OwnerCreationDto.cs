using System;
namespace Shared.DataTransferObjects
{
	public record OwnerCreationDto(string FirstName, string LastName, string? Email, string Phone,
		IEnumerable<PetCreationDto> Pets);
}

