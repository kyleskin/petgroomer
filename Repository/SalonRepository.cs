using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Entities.Models;

namespace Repository
{
    public class SalonRepository : RepositoryBase<Salon>, ISalonRepository
    {
        public SalonRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public Salon GetSalon(Guid salonId, bool trackChanges) =>
            FindByCondition(s => s.Id.Equals(salonId), trackChanges)
            .SingleOrDefault();
    }
}