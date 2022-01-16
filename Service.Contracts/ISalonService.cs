using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface ISalonService
    {
        Task<SalonDto> GetSalonAsync(Guid salonId, bool trackChanges);
    }
}