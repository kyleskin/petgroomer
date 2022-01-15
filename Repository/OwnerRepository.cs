using System;
using Contracts;
using Entities.Models;

namespace Repository
{
	internal sealed class OwnerRepository : RepositoryBase<Owner>, IOwnerRepository
	{
		public OwnerRepository(RepositoryContext repositoryContext)
			: base(repositoryContext)
        {
		}

		public IEnumerable<Owner> GetOwners(Guid salonId, bool trackChanges) =>
			FindByCondition(o => o.SalonId.Equals(salonId), trackChanges)
			.OrderBy(o => o.LastName).ToList();

		public Owner GetOwner(Guid salonId, Guid ownerId, bool trackChanges) =>
			FindByCondition(o => o.SalonId.Equals(salonId) && o.Id.Equals(ownerId), trackChanges)
			.SingleOrDefault();

		public void CreateOwner(Guid salonId, Owner owner)
		{
			owner.SalonId = salonId;
			Create(owner);
		}

		public void DeleteOwner(Owner owner) => Delete(owner);
    }
}

