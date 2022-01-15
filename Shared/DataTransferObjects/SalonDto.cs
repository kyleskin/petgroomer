using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    [Serializable]
    public record SalonDto
    {
        public Guid Id { get; init; }
        public string? Name { get; init; }
    }
}