using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class SalonNotFoundException : NotFoundException
    {
        public SalonNotFoundException(Guid salonId)
            : base($"The salon with id: {salonId} doesn't exist in the database.")
        {
        }
    }
}