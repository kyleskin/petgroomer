using System;
using Entities.Models;

namespace Contracts
{
	public interface IOwnerRepository
	{
		Task<IEnumerable<Owner>> GetOwnersAsync(Guid salonId, bool trackChanges);
		Task<Owner>? GetOwnerAsync(Guid salonId, Guid ownerId, bool trackChanges);
		void CreateOwner(Guid salonId, Owner owner);
		void DeleteOwner(Owner owner);
	}
}

