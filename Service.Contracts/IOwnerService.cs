using System;
using Shared.DataTransferObjects;

namespace Service.Contracts
{
	public interface IOwnerService
	{
		IEnumerable<OwnerDto> GetAllOwners(bool trackChanges);
	}
}

