using AutoMapper;
using Contracts;
using Service.Contracts;

namespace Service
{
    public class AppointmentService : IAppointmentService
	{
		private readonly IRepositoryManager _repository;
		private readonly ILoggerManager _logger;
		private readonly IMapper _mapper;

		public AppointmentService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
		{
			_repository = repository;
			_logger = logger;
			_mapper = mapper;
		}
	}
}

