using System;
namespace Contracts
{
	public interface IRepositoryManager
	{
		IOwnerRepository Owner { get; }
		IPetRepository Pet { get; }
		IAppointmentRepository Appointment { get; }

		void Save();
	}
}

