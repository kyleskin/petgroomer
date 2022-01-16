using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface IGroomerService
    {
        IEnumerable<GroomerDto> GetGroomers(Guid salonId, bool trackChanges);
        GroomerDto GetGroomer(Guid salonId, Guid groomerId, bool trackChanges);
        GroomerDto CreateGroomerInSalon(Guid salonId, GroomerForCreationDto groomerForCreation, bool trackChages);
        void DeleteGroomerFromSalon(Guid salonId, Guid groomerId, bool trackChages);

    }
}