using System;
using Contracts;
using Entities.Models;

namespace Repository
{
	public class PetTypeRepository : RepositoryBase<PetType>, IPetTypeRepository
	{
		public PetTypeRepository(RepositoryContext repositoryContext)
			: base(repositoryContext)
		{
		}
	}
}

