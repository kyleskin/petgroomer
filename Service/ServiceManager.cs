using System;
using Contracts;
using Service.Contracts;

namespace Service
{
	public sealed class ServiceManager : IServiceManager
	{
        private readonly Lazy<IOwnerService> _ownerService;
        private readonly Lazy<IPetService> _petService;
        private readonly Lazy<IPetTypeService> _petTypeService;
        private readonly Lazy<IAppointmentService> _appointmentService;

		public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger)
		{
            _ownerService = new Lazy<IOwnerService>(() => new OwnerService(repositoryManager, logger));
            _petService = new Lazy<IPetService>(() => new PetService(repositoryManager, logger));
            _petTypeService = new Lazy<IPetTypeService>(() => new PetTypeService(repositoryManager, logger));
            _appointmentService = new Lazy<IAppointmentService>(() => new AppointmentService(repositoryManager, logger));
		}

        public IOwnerService OwnerService => _ownerService.Value;
        public IPetService PetService => _petService.Value;
        public IPetTypeService PetTypeService => _petTypeService.Value;
        public IAppointmentService AppointmentService => _appointmentService.Value;
    }
}

