using System;
using Contracts;
using Entities.Models;

namespace Repository
{
	public class PetRepository : RepositoryBase<Pet>, IPetRepository
	{
		public PetRepository(RepositoryContext repositoryContext)
			: base(repositoryContext)
		{
		}

		public IEnumerable<Pet> GetPets(Guid ownerId, bool trackChanges) =>
			FindByCondition(p => p.OwnerId.Equals(ownerId), trackChanges)
			.OrderBy(p => p.Name).ToList();

		public Pet GetPet(Guid ownerId, Guid petId, bool trackChanges) =>
			FindByCondition(p => p.OwnerId.Equals(ownerId) && p.Id.Equals(petId), trackChanges)
			.SingleOrDefault();
	}
}

