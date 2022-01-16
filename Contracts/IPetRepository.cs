using System;
using Entities.Models;

namespace Contracts
{
	public interface IPetRepository
	{
		Task<IEnumerable<Pet>> GetPetsAsync(Guid ownerId, bool trackChanges);
		Task<Pet>? GetPetAsync(Guid ownerId, Guid petId, bool trackChanges);
		void CreatePetForOwner(Guid ownerId, Pet pet);
		void DeletePet(Pet pet);
	}
}

