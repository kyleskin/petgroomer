using System;
using Entities.Models;

namespace Contracts
{
	public interface IOwnerRepository
	{
		IEnumerable<Owner> GetOwners(Guid salonId, bool trackChanges);
		Owner? GetOwner(Guid salonId, Guid ownerId, bool trackChanges);
		void CreateOwner(Guid salonId, Owner owner);
		void DeleteOwner(Owner owner);
	}
}

