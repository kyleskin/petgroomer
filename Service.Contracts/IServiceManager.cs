using System;
namespace Service.Contracts
{
	public interface IServiceManager
	{
		IOwnerService OwnerService { get; }
		IPetService PetService { get; }
		IPetTypeService PetTypeService { get; }
		IAppointmentService AppointmentService { get; }
	}
}

