using System;
namespace Shared.DataTransferObjects
{
	public record OwnerForCreationDto(string FirstName, string LastName, string? Email, string Phone);
}

