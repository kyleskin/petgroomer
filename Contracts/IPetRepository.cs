using System;
using Entities.Models;

namespace Contracts
{
	public interface IPetRepository
	{
		IEnumerable<Pet> GetPets(Guid ownerId, bool trackChanges);
		Pet GetPet(Guid ownerId, Guid petId, bool trackChanges);
	}
}

