using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public IEnumerable<GroomerDto> GetGroomers(Guid salonId, bool trackChanges)
        {
            var salon = _repository.Salon.GetSalon(salonId, trackChanges: false);
            if (salon is null)
                throw new SalonNotFoundException(salonId);

            var groomers = _repository.Groomer.GetGroomers(salonId, trackChanges: false);
            var groomersDto = _mapper.Map<IEnumerable<GroomerDto>>(groomers);

            return groomersDto;
        }

        public GroomerDto GetGroomer(Guid salonId, Guid groomerId, bool trackChanges)
        {
            var salon = _repository.Salon.GetSalon(salonId, trackChanges);
            if (salon is null)
                throw new SalonNotFoundException(salonId);

            var groomer = _repository.Groomer.GetGroomer(salonId, groomerId, trackChanges);
            if (groomer is null)
                throw new GroomerNotFoundException(groomerId);

            var groomerDto = _mapper.Map<GroomerDto>(groomer);

            return groomerDto;
        }

        public GroomerDto CreateGroomerInSalon(Guid salonId, GroomerForCreationDto groomerForCreation, bool trackChanges)
        {
            var salon = _repository.Salon.GetSalon(salonId, trackChanges);
            if (salon is null)
                throw new SalonNotFoundException(salonId);

            var groomerEntity = _mapper.Map<Groomer>(groomerForCreation);
            _repository.Groomer.CreateGroomer(salonId, groomerEntity);
            _repository.Save();

            var groomerToReturn = _mapper.Map<GroomerDto>(groomerEntity);
            return groomerToReturn;
        }

        public void DeleteGroomerInSalon(Guid salonId, Guid groomerId, bool trackChanges)
        {
            var salon = _repository.Salon.GetSalon(salonId, trackChanges);
            if (salon is null)
                throw new SalonNotFoundException(salonId);

            var groomer = _repository.Groomer.GetGroomer(salonId, groomerId, trackChanges);
            if (groomer is null)
                throw new GroomerNotFoundException(groomerId);

            _repository.Groomer.DeleteGroomer(groomer);
            _repository.Save();
        }        
    }
}
