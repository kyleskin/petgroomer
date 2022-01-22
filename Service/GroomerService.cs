using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service
{
    public class GroomerService : IGroomerService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public GroomerService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GroomerDto>> GetGroomersAsync(Guid salonId, bool trackChanges)
        {
            var salon = await _repository.Salon.GetSalonAsync(salonId, trackChanges: false);
            if (salon is null)
                throw new SalonNotFoundException(salonId);

            var groomers = await _repository.Groomer.GetGroomersAsync(salonId, trackChanges: false);
            var groomersDto = _mapper.Map<IEnumerable<GroomerDto>>(groomers);

            return groomersDto;
        }

        public async Task<GroomerDto> GetGroomerAsync(Guid salonId, Guid groomerId, bool trackChanges)
        {
            var salon = await _repository.Salon.GetSalonAsync(salonId, trackChanges);
            if (salon is null)
                throw new SalonNotFoundException(salonId);

            var groomer = await _repository.Groomer.GetGroomerAsync(salonId, groomerId, trackChanges);
            if (groomer is null)
                throw new GroomerNotFoundException(groomerId);

            var groomerDto = _mapper.Map<GroomerDto>(groomer);

            return groomerDto;
        }

        public async Task<GroomerDto> CreateGroomerInSalonAsync(Guid salonId, GroomerCreationDto groomerForCreation, bool trackChanges)
        {
            var salon = await _repository.Salon.GetSalonAsync(salonId, trackChanges);
            if (salon is null)
                throw new SalonNotFoundException(salonId);

            var groomerEntity = _mapper.Map<Groomer>(groomerForCreation);
            _repository.Groomer.CreateGroomer(salonId, groomerEntity);
            await _repository.SaveAsync();

            var groomerToReturn = _mapper.Map<GroomerDto>(groomerEntity);
            return groomerToReturn;
        }

        public async Task DeleteGroomerFromSalonAsync(Guid salonId, Guid groomerId, bool trackChanges)
        {
            var salon = await _repository.Salon.GetSalonAsync(salonId, trackChanges);
            if (salon is null)
                throw new SalonNotFoundException(salonId);

            var groomer = await _repository.Groomer.GetGroomerAsync(salonId, groomerId, trackChanges);
            if (groomer is null)
                throw new GroomerNotFoundException(groomerId);

            _repository.Groomer.DeleteGroomer(groomer);
            await _repository.SaveAsync();
        }        
    }
}
