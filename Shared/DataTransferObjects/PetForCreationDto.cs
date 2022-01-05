using System;
using Entities;

namespace Shared.DataTransferObjects
{
	public record PetForCreationDto(string Name, string? Notes, string Type) { }
}

