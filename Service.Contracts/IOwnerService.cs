using System;
using Shared.DataTransferObjects;

namespace Service.Contracts
{
	public interface IOwnerService
	{
		IEnumerable<OwnerDto> GetOwners(Guid salonId, bool trackChanges);
		OwnerDto GetOwner(Guid salonId, Guid ownerId, bool trackChanges);
		OwnerDto CreateOwner(Guid salonId, OwnerForCreationDto owner);
		void DeleteOwner(Guid salondId, Guid ownerId, bool trackChanges);
		void UpdateOwner(Guid salondId, Guid ownerId, OwnerForUpdateDto ownerForUpdate, bool trackChanges);
	}
}

