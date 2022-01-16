using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class SalonRepository : RepositoryBase<Salon>, ISalonRepository
    {
        public SalonRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<Salon>? GetSalonAsync(Guid salonId, bool trackChanges) =>
            await FindByCondition(s => s.Id.Equals(salonId), trackChanges)
            .SingleOrDefaultAsync();
    }
}