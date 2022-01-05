using System;
using Entities;

namespace Shared.DataTransferObjects
{
		public record PetDto(Guid Id, string? Name, string? Notes, PetTypes Type)
		{ }
}

