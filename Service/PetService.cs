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

		public async Task<IEnumerable<PetDto>> GetPetsAsync(Guid salonId, Guid ownerId, bool trackChanges)
        {
			var owner = await _repository.Owner.GetOwnerAsync(salonId, ownerId, trackChanges);
			if (owner is null)
				throw new OwnerNotFoundException(ownerId);

			var petsFromDb = await _repository.Pet.GetPetsAsync(ownerId, trackChanges);
			var petsDto = _mapper.Map<IEnumerable<PetDto>>(petsFromDb);

			return petsDto;
        }

		public async Task<PetDto> GetPetAsync(Guid salonId, Guid ownerId, Guid petId, bool trackChanges)
        {
			var owner = await _repository.Owner.GetOwnerAsync(salonId, ownerId, trackChanges);
			if (owner is null)
				throw new OwnerNotFoundException(ownerId);

			var petDb = await _repository.Pet.GetPetAsync(ownerId, petId, trackChanges);
			if (petDb is null)
				throw new PetNotFoundException(petId);

			var petDto = _mapper.Map<PetDto>(petDb);
			return petDto;
        }

		public async Task<PetDto> CreatePetForOwnerAsync(Guid salonId, Guid ownerId, PetForCreationDto petForCreation, bool trackChanges)
        {
			var owner = await _repository.Owner.GetOwnerAsync(salonId, ownerId, trackChanges);
			if (owner is null)
				throw new OwnerNotFoundException(ownerId);

			var petEntity = _mapper.Map<Pet>(petForCreation);

			_repository.Pet.CreatePetForOwner(ownerId, petEntity);
			await _repository.SaveAsync();

			var petToReturn = _mapper.Map<PetDto>(petEntity);

			return petToReturn;
        }

		public async Task DeletePetForOwnerAsync(Guid salonId, Guid ownerId, Guid id, bool trackChanges)
		{
			var owner = await _repository.Owner.GetOwnerAsync(salonId, ownerId, trackChanges);
			if (owner is null)
				throw new OwnerNotFoundException(ownerId);

			var petForOwner = await _repository.Pet.GetPetAsync(ownerId, id, trackChanges);
			if (petForOwner is null)
				throw new PetNotFoundException(id);

			_repository.Pet.DeletePet(petForOwner);
			await _repository.SaveAsync();
		}

        public async Task UpdatePetForOwnerAsync(Guid salonId, Guid ownerId, Guid id, PetForUpdateDto petForUpdate, bool ownerTrackChanges, bool petTrackChanges)
        {
            var owner = await _repository.Owner.GetOwnerAsync(salonId, ownerId, trackChanges: ownerTrackChanges);
			if (owner is null)
				throw new OwnerNotFoundException(ownerId);

			var pet = await _repository.Pet.GetPetAsync(ownerId, id, trackChanges: petTrackChanges);
			if (pet is null)
				throw new PetNotFoundException(id);

			_mapper.Map(petForUpdate, pet);
			await _repository.SaveAsync();
        }

        public async Task<(PetForUpdateDto petToPatch, Pet petEntity)> GetPetForPatchAsync(Guid salonId, Guid ownerId, Guid id, bool ownerTrackChanges, bool petTrackChanges)
        {
            var owner = await _repository.Owner.GetOwnerAsync(salonId, ownerId, ownerTrackChanges);
			if (owner is null)
				throw new OwnerNotFoundException(ownerId);

			var petEntity = await _repository.Pet.GetPetAsync(ownerId, id, petTrackChanges);
			if (petEntity is null)
				throw new PetNotFoundException(id);

			var petToPatch = _mapper.Map<PetForUpdateDto>(petEntity);

			return (petToPatch, petEntity);
        }

        public async Task SaveChangesForPatchAsync(PetForUpdateDto petToPatch, Pet petEntity)
        {
            _mapper.Map(petToPatch, petEntity);
			await _repository.SaveAsync();
        }
    }
}

