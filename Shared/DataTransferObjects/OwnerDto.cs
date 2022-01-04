using System;
namespace Shared.DataTransferObjects
{
	public record OwnerDto(Guid Id, string? FirstName, string? LastName, string? Email, string? Phone);
}

