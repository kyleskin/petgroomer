using System;
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

		public IEnumerable<OwnerDto> GetAllOwners(bool trackChanges)
        {
			var owners = _repository.Owner.GetAllOwners(trackChanges);
			var ownersDto = _mapper.Map<IEnumerable<OwnerDto>>(owners);
			return ownersDto;
        }

		public OwnerDto GetOwner(Guid ownerId, bool trackChanges)
        {
			var owner = _repository.Owner.GetOwner(ownerId, trackChanges);
			if (owner is null)
				throw new OwnerNotFoundException(ownerId);

			var ownerDto = _mapper.Map<OwnerDto>(owner);
			return ownerDto;
        }
	}
}

