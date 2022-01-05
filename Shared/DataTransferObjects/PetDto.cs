using System;
namespace Shared.DataTransferObjects
{
		public record PetDto(Guid Id, string? Name, string? Notes)
		{ }
}

