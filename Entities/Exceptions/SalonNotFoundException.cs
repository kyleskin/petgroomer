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