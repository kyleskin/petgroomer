using System;
using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects;
using AutoMapper.Extensions.EnumMapping;

namespace PetGroomer
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<Owner, OwnerDto>();

			CreateMap<Pet, PetDto>();

			CreateMap<OwnerForCreationDto, Owner>();

			CreateMap<PetForCreationDto, Pet>();
		}
	}
}

