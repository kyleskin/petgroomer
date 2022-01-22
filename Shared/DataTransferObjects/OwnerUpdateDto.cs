using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record OwnerUpdateDto(string FirstName, string LastName, string Email, string Phone,
        IEnumerable<PetCreationDto> Pets);
}