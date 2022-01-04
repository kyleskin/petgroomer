using System;
namespace Contracts
{
	public interface IRepositoryManager
	{
		IOwnerRepository Owner { get; }
		IPetRepository Pet { get; }
		IPetTypeRepository PetType { get; }
		IAppointmentRepository Appointment { get; }

		void Save();
	}
}

