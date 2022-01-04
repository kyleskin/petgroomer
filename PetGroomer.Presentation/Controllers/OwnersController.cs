﻿using System;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace PetGroomer.Presentation.Controllers
{
	[Route("api/owners")]
	[ApiController]
	public class OwnersController : ControllerBase
	{
		private readonly IServiceManager _service;

		public OwnersController(IServiceManager service) => _service = service;

		[HttpGet]
		public IActionResult GetOwners()
        {
			var owners = _service.OwnerService.GetAllOwners(trackChanges: false);

			return Ok(owners);
		}
	}
}

