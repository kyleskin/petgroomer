using System;
namespace Service.Contracts
{
	public interface IServiceManager
	{
		IOwnerService OwnerService { get; }
		IPetService PetService { get; }
		IAppointmentService AppointmentService { get; }
		ISalonService SalonService { get; }
		IGroomerService GroomerService { get; }
		IAuthenticationService AuthenticationService { get; }
	}
}

