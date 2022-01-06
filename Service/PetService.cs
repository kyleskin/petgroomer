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

		public void DeletePetForOwner(Guid ownerId, Guid id, bool trackChanges)
		{
			var owner = _repository.Owner.GetOwner(ownerId, trackChanges);
			if (owner is null)
				throw new OwnerNotFoundException(ownerId);

			var petForOwner = _repository.Pet.GetPet(ownerId, id, trackChanges);
			if (petForOwner is null)
				throw new PetNotFoundException(id);

			_repository.Pet.DeletePet(petForOwner);
			_repository.Save();
		}

        public void UpdatePetForOwner(Guid ownerId, Guid id, PetForUpdateDto petForUpdate, bool ownerTrackChanges, bool petTrackChanges)
        {
            var owner = _repository.Owner.GetOwner(ownerId, trackChanges: ownerTrackChanges);
			if (owner is null)
				throw new OwnerNotFoundException(ownerId);

			var pet = _repository.Pet.GetPet(ownerId, id, trackChanges: petTrackChanges);
			if (pet is null)
				throw new PetNotFoundException(id);

			_mapper.Map(petForUpdate, pet);
			_repository.Save();
        }

        public (PetForUpdateDto petToPatch, Pet petEntity) GetPetForPatch(Guid ownerId, Guid id, bool ownerTrackChanges, bool petTrackChanges)
        {
            var owner = _repository.Owner.GetOwner(ownerId, ownerTrackChanges);
			if (owner is null)
				throw new OwnerNotFoundException(ownerId);

			var petEntity = _repository.Pet.GetPet(ownerId, id, petTrackChanges);
			if (petEntity is null)
				throw new PetNotFoundException(id);

			var petToPatch = _mapper.Map<PetForUpdateDto>(petEntity);

			return (petToPatch, petEntity);
        }

        public void SaveChangesForPatch(PetForUpdateDto petToPatch, Pet petEntity)
        {
            _mapper.Map(petToPatch, petEntity);
			_repository.Save();
        }
    }
}

