using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects;

namespace PetGroomer
{
    public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<Owner, OwnerDto>();

			CreateMap<Pet, PetDto>();

			CreateMap<OwnerCreationDto, Owner>();

			CreateMap<PetCreationDto, Pet>();

			CreateMap<PetUpdateDto, Pet>().ReverseMap();

			CreateMap<OwnerUpdateDto, Owner>();

			CreateMap<Salon, SalonDto>();

			CreateMap<Groomer, GroomerDto>();
			CreateMap<GroomerCreationDto, Groomer>();

			CreateMap<UserRegistrationDto, User>();
		}
	}
}

