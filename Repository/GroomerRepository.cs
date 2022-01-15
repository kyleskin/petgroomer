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
    }
}