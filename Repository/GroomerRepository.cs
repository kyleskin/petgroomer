using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class GroomerRepository : RepositoryBase<Groomer>, IGroomerRepository
    {
        public GroomerRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Groomer>> GetGroomersAsync(Guid salonId, bool trackChanges) =>
            await FindByCondition(g => g.SalonId.Equals(salonId), trackChanges)
            .OrderBy(g => g.LastName)
            .ToListAsync();

        public async Task<Groomer>? GetGroomerAsync(Guid salonId, Guid groomerId, bool trackChanges) =>
            await FindByCondition(g => g.SalonId.Equals(salonId) && g.Id.Equals(groomerId), trackChanges)
            .SingleOrDefaultAsync();
        public void CreateGroomer(Guid salonId, Groomer groomer)
        {
            groomer.SalonId = salonId;
            Create(groomer);
        }

        public void DeleteGroomer(Groomer groomer) => Delete(groomer);
    }
}