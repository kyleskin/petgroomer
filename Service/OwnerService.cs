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

		public async Task<IEnumerable<OwnerDto>> GetOwnersAsync(Guid salonId, bool trackChanges)
        {
			var owners = await _repository.Owner.GetOwnersAsync(salonId, trackChanges);
			var ownersDto = _mapper.Map<IEnumerable<OwnerDto>>(owners);
			return ownersDto;
        }

		public async Task<OwnerDto> GetOwnerAsync(Guid salonId, Guid ownerId, bool trackChanges)
        {
			var owner = await _repository.Owner.GetOwnerAsync(salonId, ownerId, trackChanges);
			if (owner is null)
				throw new OwnerNotFoundException(ownerId);

			var ownerDto = _mapper.Map<OwnerDto>(owner);
			return ownerDto;
        }

		public async Task<OwnerDto> CreateOwnerAsync(Guid salonId, OwnerForCreationDto owner)
        {
			var ownerEntity = _mapper.Map<Owner>(owner);

			_repository.Owner.CreateOwner(salonId, ownerEntity);
			await _repository.SaveAsync();

			var ownerToReturn = _mapper.Map<OwnerDto>(ownerEntity);

			return ownerToReturn;
        }

		public async Task DeleteOwnerAsync(Guid salonId, Guid ownerId, bool trackChanges)
		{
			var owner = await _repository.Owner.GetOwnerAsync(salonId, ownerId, trackChanges);
			if (owner is null)
				throw new OwnerNotFoundException(ownerId);

			_repository.Owner.DeleteOwner(owner);
			await _repository.SaveAsync();
		}

        public async Task UpdateOwnerAsync(Guid salonId, Guid ownerId, OwnerForUpdateDto ownerForUpdate, bool trackChanges)
        {
            var owner = await _repository.Owner.GetOwnerAsync(salonId, ownerId, trackChanges);
			if (owner is null)
				throw new OwnerNotFoundException(ownerId);

			_mapper.Map(ownerForUpdate, owner);
			await _repository.SaveAsync();
        }
    }
}

