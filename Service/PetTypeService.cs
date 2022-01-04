using System;
using AutoMapper;
using Contracts;
using Service.Contracts;

namespace Service
{
	public class PetTypeService : IPetTypeService
	{
		private readonly IRepositoryManager _repository;
		private readonly ILoggerManager _logger;
		private readonly IMapper _mapper;

		public PetTypeService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
		{
			_repository = repository;
			_logger = logger;
			_mapper = mapper;
		}
	}
}

