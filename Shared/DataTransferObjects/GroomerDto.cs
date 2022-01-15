using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record GroomerDto(Guid Id, string? FirstName, string? LastName)
    {}
}