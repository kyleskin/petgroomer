using System;
using Contracts;
using Service.Contracts;

namespace Service
{
	public class PetTypeService : IPetTypeService
	{
		private readonly IRepositoryManager _repository;
		private readonly ILoggerManager _logger;

		public PetTypeService(IRepositoryManager repository, ILoggerManager logger)
		{
			_repository = repository;
			_logger = logger;
		}
	}
}

