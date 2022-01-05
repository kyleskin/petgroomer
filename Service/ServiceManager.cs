﻿using System;
using AutoMapper;
using Contracts;
using Service.Contracts;

namespace Service
{
	public sealed class ServiceManager : IServiceManager
	{
        private readonly Lazy<IOwnerService> _ownerService;
        private readonly Lazy<IPetService> _petService;
        private readonly Lazy<IAppointmentService> _appointmentService;

		public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper)
		{
            _ownerService = new Lazy<IOwnerService>(() => new OwnerService(repositoryManager, logger, mapper));
            _petService = new Lazy<IPetService>(() => new PetService(repositoryManager, logger, mapper));
            _appointmentService = new Lazy<IAppointmentService>(() => new AppointmentService(repositoryManager, logger, mapper));
		}

        public IOwnerService OwnerService => _ownerService.Value;
        public IPetService PetService => _petService.Value;
        public IAppointmentService AppointmentService => _appointmentService.Value;
    }
}

