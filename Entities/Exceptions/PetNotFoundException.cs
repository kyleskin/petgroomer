namespace Entities.Exceptions
{
    public class PetNotFoundException : NotFoundException
	{
		public PetNotFoundException(Guid petId)
			: base($"Pet with id: {petId} doesn't exist in the database.")
		{
		}
	}
}

