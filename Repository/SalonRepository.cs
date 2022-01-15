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
    }
}