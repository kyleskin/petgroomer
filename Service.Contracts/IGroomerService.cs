using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface IGroomerService
    {
        Task<IEnumerable<GroomerDto>> GetGroomersAsync(Guid salonId, bool trackChanges);
        Task<GroomerDto> GetGroomerAsync(Guid salonId, Guid groomerId, bool trackChanges);
        Task<GroomerDto> CreateGroomerInSalonAsync(Guid salonId, GroomerCreationDto groomerForCreation, bool trackChages);
        Task DeleteGroomerFromSalonAsync(Guid salonId, Guid groomerId, bool trackChages);

    }
}