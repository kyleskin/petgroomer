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

		public IEnumerable<Owner> GetAllOwners(bool trackChanges) =>
			FindAll(trackChanges)
				.OrderBy(o => o.LastName)
				.ToList();
    }
}

