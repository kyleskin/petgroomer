using System;
using Shared.DataTransferObjects;

namespace Service.Contracts
{
	public interface IPetService
	{
		IEnumerable<PetDto> GetPets(Guid ownerId, bool trackChanges);
		PetDto GetPet(Guid ownerId, Guid petId, bool trackChanges);
	}
}

