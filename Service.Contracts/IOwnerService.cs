﻿using System;
using Shared.DataTransferObjects;

namespace Service.Contracts
{
	public interface IOwnerService
	{
		IEnumerable<OwnerDto> GetAllOwners(bool trackChanges);
		OwnerDto GetOwner(Guid ownerId, bool trackChanges);
	}
}

