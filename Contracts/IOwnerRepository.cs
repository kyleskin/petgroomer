using System;
using Entities.Models;

namespace Contracts
{
	public interface IOwnerRepository
	{
		IEnumerable<Owner> GetAllOwners(bool trackChanges);
		Owner GetOwner(Guid ownerId, bool trackChanges);
		void CreateOwner(Owner owner);
		void DeleteOwner(Owner owner);
	}
}

