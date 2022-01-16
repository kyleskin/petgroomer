using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models;

namespace Contracts
{
    public interface IGroomerRepository
    {
        IEnumerable<Groomer> GetGroomers(Guid salonId, bool trackChanges);
        Groomer? GetGroomer(Guid salonId, Guid groomerId, bool trackChanges);
        void CreateGroomer(Guid salonId, Groomer groomer);
        void DeleteGroomer(Groomer groomer);
    }
}