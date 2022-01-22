namespace Entities.Exceptions
{
    public class GroomerNotFoundException : NotFoundException
    {
        public GroomerNotFoundException(Guid groomerId)
            : base($"The groomer with id: {groomerId} doesn't exist in the database.")
        {}
    }
}