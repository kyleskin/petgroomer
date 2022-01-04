using System;
namespace Entities.Exceptions
{
	public class OwnerNotFoundException : NotFoundException
	{
		public OwnerNotFoundException(Guid ownerId)
			: base($"This owner with id: {ownerId} doesn't exist in the database.")
		{
		}
	}
}

