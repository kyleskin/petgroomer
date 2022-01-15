using System;
using Entities.Models;
using Shared.DataTransferObjects;

namespace Service.Contracts
{
	public interface IPetService
	{
		IEnumerable<PetDto> GetPets(Guid salonId, Guid ownerId, bool trackChanges);
		PetDto GetPet(Guid salonId, Guid ownerId, Guid petId, bool trackChanges);
		PetDto CreatePetForOwner(Guid salonId, Guid ownerId, PetForCreationDto petForCreationDto, bool trackChanges);
		void DeletePetForOwner(Guid salonId, Guid ownerId, Guid id, bool trackChanges);
		void UpdatePetForOwner(Guid salonId, Guid ownerId, Guid id, PetForUpdateDto petForUpdate, bool ownerTrackChanges, bool petTrackChanges);
		(PetForUpdateDto petToPatch, Pet petEntity) GetPetForPatch(Guid salonId, Guid ownerId, Guid id, bool ownerTrackChanges, bool petTrackChanges);
		void SaveChangesForPatch(PetForUpdateDto petToPatch, Pet petEntity);
	}
}

