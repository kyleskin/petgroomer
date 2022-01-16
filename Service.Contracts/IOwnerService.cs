using System;
using Shared.DataTransferObjects;

namespace Service.Contracts
{
	public interface IOwnerService
	{
		Task<IEnumerable<OwnerDto>> GetOwnersAsync(Guid salonId, bool trackChanges);
		Task<OwnerDto> GetOwnerAsync(Guid salonId, Guid ownerId, bool trackChanges);
		Task<OwnerDto> CreateOwnerAsync(Guid salonId, OwnerForCreationDto owner);
		Task DeleteOwnerAsync(Guid salondId, Guid ownerId, bool trackChanges);
		Task UpdateOwnerAsync(Guid salondId, Guid ownerId, OwnerForUpdateDto ownerForUpdate, bool trackChanges);
	}
}

