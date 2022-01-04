using System;
using Contracts;
using Service.Contracts;
using Entities.Models;

namespace Service
{
	internal sealed class OwnerService : IOwnerService
	{
		private readonly IRepositoryManager _repository;
		private readonly ILoggerManager _logger;

		public OwnerService(IRepositoryManager repository, ILoggerManager logger)
		{
			_repository = repository;
			_logger = logger;
		}

		public IEnumerable<Owner> GetAllOwners(bool trackChanges)
        {
			try
            {
				var owners = _repository.Owner.GetAllOwners(trackChanges);

				return owners;
            }
			catch (Exception ex)
            {
				_logger.LogError($"Something went wrong in the {nameof(GetAllOwners)} service method {ex}");
				throw;
            }
        }
	}
}

