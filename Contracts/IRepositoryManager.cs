using System;
namespace Contracts
{
	public interface IRepositoryManager
	{
		IOwnerRepository Owner { get; }
		IPetRepository Pet { get; }
		IAppointmentRepository Appointment { get; }
		ISalonRepository Salon { get; }
		IGroomerRepository Groomer { get; }

		Task SaveAsync();
	}
}

