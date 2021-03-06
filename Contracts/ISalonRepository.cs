using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models;

namespace Contracts
{
    public interface ISalonRepository
    {
        Task<Salon>? GetSalonAsync(Guid salonId, bool trackChanges);
    }
}