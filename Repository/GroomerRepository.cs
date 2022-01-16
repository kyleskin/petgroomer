using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Entities.Models;

namespace Repository
{
    public class GroomerRepository : RepositoryBase<Groomer>, IGroomerRepository
    {
        public GroomerRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<Groomer> GetGroomers(Guid salonId, bool trackChanges) =>
            FindByCondition(g => g.SalonId.Equals(salonId), trackChanges)
            .OrderBy(g => g.LastName).ToList();

        public Groomer? GetGroomer(Guid salonId, Guid groomerId, bool trackChanges) =>
            FindByCondition(g => g.SalonId.Equals(salonId) && g.Id.Equals(groomerId), trackChanges)
            .SingleOrDefault();
        public void CreateGroomer(Guid salonId, Groomer groomer)
        {
            groomer.SalonId = salonId;
            Create(groomer);
        }

        public void DeleteGroomer(Groomer groomer) => Delete(groomer);

        

    }
}