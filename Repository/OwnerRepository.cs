using System;
using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Shared.RequestFeatures;

namespace Repository
{
	internal sealed class OwnerRepository : RepositoryBase<Owner>, IOwnerRepository
	{
		public OwnerRepository(RepositoryContext repositoryContext)
			: base(repositoryContext)
        {
		}

		public async Task<PagedList<Owner>> GetOwnersAsync(Guid salonId, OwnerParameters ownerParameters,bool trackChanges)
		{
			var owners = await FindByCondition(o => o.SalonId.Equals(salonId), trackChanges)
			.OrderBy(o => o.LastName)
			.ToListAsync();

			return PagedList<Owner>
				.ToPagedList(owners, ownerParameters.PageNumber, ownerParameters.PageSize);
		}
			

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

