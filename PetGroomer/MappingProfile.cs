﻿using System;
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
		}
	}
}

