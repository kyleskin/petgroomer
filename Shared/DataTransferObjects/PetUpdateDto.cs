using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record PetUpdateDto(string Name, string? Notes, string Type);
}