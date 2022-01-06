using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record PetForUpdateDto(string Name, string? Notes, string Type);
}