using System;
using Contracts;
using Service.Contracts;

namespace Service
{
	public class AppointmentService : IAppointmentService
	{
		private readonly IRepositoryManager _repository;
		private readonly ILoggerManager _logger;

		public AppointmentService(IRepositoryManager repository, ILoggerManager logger)
		{
			_repository = repository;
			_logger = logger;
		}
	}
}

