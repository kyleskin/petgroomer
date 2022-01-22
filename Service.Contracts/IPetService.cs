using System;
using Entities.Models;
using Shared.DataTransferObjects;

namespace Service.Contracts
{
	public interface IPetService
	{
		Task<IEnumerable<PetDto>> GetPetsAsync(Guid salonId, Guid ownerId, bool trackChanges);
		Task<PetDto> GetPetAsync(Guid salonId, Guid ownerId, Guid petId, bool trackChanges);
		Task<PetDto> CreatePetForOwnerAsync(Guid salonId, Guid ownerId, PetCreationDto petForCreationDto, bool trackChanges);
		Task DeletePetForOwnerAsync(Guid salonId, Guid ownerId, Guid id, bool trackChanges);
		Task UpdatePetForOwnerAsync(Guid salonId, Guid ownerId, Guid id, PetUpdateDto petForUpdate, bool ownerTrackChanges, bool petTrackChanges);
		Task<(PetUpdateDto petToPatch, Pet petEntity)> GetPetForPatchAsync(Guid salonId, Guid ownerId, Guid id, bool ownerTrackChanges, bool petTrackChanges);
		Task SaveChangesForPatchAsync(PetUpdateDto petToPatch, Pet petEntity);
	}
}

