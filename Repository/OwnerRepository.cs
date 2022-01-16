using System;
using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
	internal sealed class OwnerRepository : RepositoryBase<Owner>, IOwnerRepository
	{
		public OwnerRepository(RepositoryContext repositoryContext)
			: base(repositoryContext)
        {
		}

		public async Task<IEnumerable<Owner>> GetOwnersAsync(Guid salonId, bool trackChanges) =>
			await FindByCondition(o => o.SalonId.Equals(salonId), trackChanges)
			.OrderBy(o => o.LastName)
			.ToListAsync();

		public async Task<Owner>? GetOwnerAsync(Guid salonId, Guid ownerId, bool trackChanges) =>
			await FindByCondition(o => o.SalonId.Equals(salonId) && o.Id.Equals(ownerId), trackChanges)
			.SingleOrDefaultAsync();

		public void CreateOwner(Guid salonId, Owner owner)
		{
			owner.SalonId = salonId;
			Create(owner);
		}

		public void DeleteOwner(Owner owner) => Delete(owner);
    }
}

