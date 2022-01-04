using System;
using Entities.Models;

namespace Service.Contracts
{
	public interface IOwnerService
	{
		IEnumerable<Owner> GetAllOwners(bool trackChanges);
	}
}

