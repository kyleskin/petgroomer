﻿using System;
using Contracts;
using Service.Contracts;
using Entities.Models;
using Shared.DataTransferObjects;
using AutoMapper;
using Entities.Exceptions;

namespace Service
{
	internal sealed class OwnerService : IOwnerService
	{
		private readonly IRepositoryManager _repository;
		private readonly ILoggerManager _logger;
		private readonly IMapper _mapper;

		public OwnerService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
		{
			_repository = repository;
			_logger = logger;
			_mapper = mapper;
		}

		public IEnumerable<OwnerDto> GetOwners(Guid salonId, bool trackChanges)
        {
			var owners = _repository.Owner.GetOwners(salonId, trackChanges);
			var ownersDto = _mapper.Map<IEnumerable<OwnerDto>>(owners);
			return ownersDto;
        }

		public OwnerDto GetOwner(Guid salonId, Guid ownerId, bool trackChanges)
        {
			var owner = _repository.Owner.GetOwner(salonId, ownerId, trackChanges);
			if (owner is null)
				throw new OwnerNotFoundException(ownerId);

			var ownerDto = _mapper.Map<OwnerDto>(owner);
			return ownerDto;
        }

		public OwnerDto CreateOwner(Guid salonId, OwnerForCreationDto owner)
        {
			var ownerEntity = _mapper.Map<Owner>(owner);

			_repository.Owner.CreateOwner(salonId, ownerEntity);
			_repository.Save();

			var ownerToReturn = _mapper.Map<OwnerDto>(ownerEntity);

			return ownerToReturn;
        }

		public void DeleteOwner(Guid salonId, Guid ownerId, bool trackChanges)
		{
			var owner = _repository.Owner.GetOwner(salonId, ownerId, trackChanges);
			if (owner is null)
				throw new OwnerNotFoundException(ownerId);

			_repository.Owner.DeleteOwner(owner);
			_repository.Save();
		}

        public void UpdateOwner(Guid salonId, Guid ownerId, OwnerForUpdateDto ownerForUpdate, bool trackChanges)
        {
            var owner = _repository.Owner.GetOwner(salonId, ownerId, trackChanges);
			if (owner is null)
				throw new OwnerNotFoundException(ownerId);

			_mapper.Map(ownerForUpdate, owner);
			_repository.Save();
        }
    }
}

