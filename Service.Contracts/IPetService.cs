using System;
using Shared.DataTransferObjects;

namespace Service.Contracts
{
	public interface IPetService
	{
		IEnumerable<PetDto> GetPets(Guid ownerId, bool trackChanges);
		PetDto GetPet(Guid ownerId, Guid petId, bool trackChanges);
		PetDto CreatePetForOwner(Guid ownerId, PetForCreationDto petForCreationDto, bool trackChanges);
		void DeletePetForOwner(Guid ownerId, Guid id, bool trackChanges);
		void UpdatePetForOwner(Guid ownerId, Guid id, PetForUpdateDto petForUpdate, bool ownerTrackChanges, bool petTrackChanges);
	}
}

