using System;
namespace Shared.DataTransferObjects
{
	[Serializable]
	public record OwnerDto
    {
        public Guid Id { get; init; }
        public string? FirstName { get; init; }
        public string? LastName { get; init; }
        public string? Email { get; init; }
        public string? Phone { get; init; }
    }
}

