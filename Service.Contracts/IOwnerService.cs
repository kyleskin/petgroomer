using System;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;

namespace Service.Contracts
{
	public interface IOwnerService
	{
		Task<(IEnumerable<OwnerDto> owners, MetaData metaData)> GetOwnersAsync(Guid salonId, OwnerParameters ownerParameters, bool trackChanges);
		Task<OwnerDto> GetOwnerAsync(Guid salonId, Guid ownerId, bool trackChanges);
		Task<OwnerDto> CreateOwnerAsync(Guid salonId, OwnerCreationDto owner);
		Task DeleteOwnerAsync(Guid salondId, Guid ownerId, bool trackChanges);
		Task UpdateOwnerAsync(Guid salondId, Guid ownerId, OwnerUpdateDto ownerForUpdate, bool trackChanges);
	}
}

