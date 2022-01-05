using System;
namespace Shared.DataTransferObjects
{
	public record PetForCreationDto(string Name, string? Notes, string PetType) { }
}

