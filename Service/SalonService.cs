using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service
{
    public class SalonService : ISalonService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public SalonService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<SalonDto> GetSalonAsync(Guid salonId, bool trackChanges)
        {
            var salon = await _repository.Salon.GetSalonAsync(salonId, trackChanges);
            if (salon is null)
                throw new SalonNotFoundException(salonId);

            var salonDto = _mapper.Map<SalonDto>(salon);
            return salonDto;
        }
    }
}