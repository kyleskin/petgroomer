using System;
using Entities;

namespace Shared.DataTransferObjects
{
	public record PetCreationDto(string Name, string? Notes, string Type) { }
}

