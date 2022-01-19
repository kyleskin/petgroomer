using System;
using Entities.Models;
using Shared.RequestFeatures;

namespace Contracts
{
	public interface IOwnerRepository
	{
		Task<PagedList<Owner>> GetOwnersAsync(Guid salonId, OwnerParameters ownerParameters, bool trackChanges);
		Task<Owner>? GetOwnerAsync(Guid salonId, Guid ownerId, bool trackChanges);
		void CreateOwner(Guid salonId, Owner owner);
		void DeleteOwner(Owner owner);
	}
}

