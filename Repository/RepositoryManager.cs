using System;
using Contracts;

namespace Repository
{
	public class RepositoryManager : IRepositoryManager
	{
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<IOwnerRepository> _ownerRepository;
        private readonly Lazy<IPetRepository> _petRepository;
        private readonly Lazy<IAppointmentRepository> _appointmentRepository;

		public RepositoryManager(RepositoryContext repositoryContext)
		{
            _repositoryContext = repositoryContext;
            _ownerRepository = new Lazy<IOwnerRepository>(() => new OwnerRepository(repositoryContext));
            _petRepository = new Lazy<IPetRepository>(() => new PetRepository(repositoryContext));
            _appointmentRepository = new Lazy<IAppointmentRepository>(() => new AppointmentRepository(repositoryContext));
		}

        public IOwnerRepository Owner => _ownerRepository.Value;

        public IPetRepository Pet => _petRepository.Value;

        public IAppointmentRepository Appointment => _appointmentRepository.Value;

        public void Save() => _repositoryContext.SaveChanges();
    }
}

