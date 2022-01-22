using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class PetRepository : RepositoryBase<Pet>, IPetRepository
	{
		public PetRepository(RepositoryContext repositoryContext)
			: base(repositoryContext)
		{
		}

		public async Task<IEnumerable<Pet>> GetPetsAsync(Guid ownerId, bool trackChanges) =>
			await FindByCondition(p => p.OwnerId.Equals(ownerId), trackChanges)
			.OrderBy(p => p.Name)
			.ToListAsync();

		public async Task<Pet>? GetPetAsync(Guid ownerId, Guid petId, bool trackChanges) =>
			await FindByCondition(p => p.OwnerId.Equals(ownerId) && p.Id.Equals(petId), trackChanges)
			.SingleOrDefaultAsync();

		public void CreatePetForOwner(Guid ownerId, Pet pet)
        {
			pet.OwnerId = ownerId;
			Create(pet);
		}

        public void DeletePet(Pet pet) => Delete(pet);
    }
}

