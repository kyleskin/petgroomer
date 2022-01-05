using System;
using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service
{
	public class PetService : IPetService
	{
		private readonly IRepositoryManager _repository;
		private readonly ILoggerManager _logger;
		private readonly IMapper _mapper;

		public PetService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
		{
			_repository = repository;
			_logger = logger;
			_mapper = mapper;
		}

		public IEnumerable<PetDto> GetPets(Guid ownerId, bool trackChanges)
        {
			var owner = _repository.Owner.GetOwner(ownerId, trackChanges);
			if (owner is null)
				throw new OwnerNotFoundException(ownerId);

			var petsFromDb = _repository.Pet.GetPets(ownerId, trackChanges);
			var petsDto = _mapper.Map<IEnumerable<PetDto>>(petsFromDb);

			return petsDto;
        }

		public PetDto GetPet(Guid ownerId, Guid petId, bool trackChanges)
        {
			var owner = _repository.Owner.GetOwner(ownerId, trackChanges);
			if (owner is null)
				throw new OwnerNotFoundException(ownerId);

			var petDb = _repository.Pet.GetPet(ownerId, petId, trackChanges);
			if (petDb is null)
				throw new PetNotFoundException(petId);

			var petDto = _mapper.Map<PetDto>(petDb);
			return petDto;
        }

		public PetDto CreatePetForOwner(Guid ownerId, PetForCreationDto petForCreation, bool trackChanges)
        {
			var owner = _repository.Owner.GetOwner(ownerId, trackChanges);
			if (owner is null)
				throw new OwnerNotFoundException(ownerId);

			var petEntity = _mapper.Map<Pet>(petForCreation);

			_repository.Pet.CreatePetForOwner(ownerId, petEntity);
			_repository.Save();

			var petToReturn = _mapper.Map<PetDto>(petEntity);

			return petToReturn;
        }
	}
}

