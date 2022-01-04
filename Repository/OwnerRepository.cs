using System;
using Contracts;
using Entities.Models;

namespace Repository
{
	public class OwnerRepository : RepositoryBase<Owner>, IOwnerRepository
	{
		public OwnerRepository(RepositoryContext repositoryContext)
			: base(repositoryContext)
        {
		}
	}
}

