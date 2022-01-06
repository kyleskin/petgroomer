using System;
using Shared.DataTransferObjects;

namespace Service.Contracts
{
	public interface IOwnerService
	{
		IEnumerable<OwnerDto> GetAllOwners(bool trackChanges);
		OwnerDto GetOwner(Guid ownerId, bool trackChanges);
		OwnerDto CreateOwner(OwnerForCreationDto owner);
		void DeleteOwner(Guid ownerId, bool trackChanges);
		void UpdateOwner(Guid ownerId, OwnerForUpdateDto ownerForUpdate, bool trackChanges);
	}
}

