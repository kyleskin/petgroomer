using System;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace PetGroomer.Presentation.Controllers
{
	[Route("api/owners/{ownerId}/pets")]
	[ApiController]
	public class PetsController : ControllerBase
	{
		private readonly IServiceManager _service;

		public PetsController(IServiceManager service) => _service = service;

		[HttpGet]
		public IActionResult GetPetsForOwner(Guid ownerId)
        {
			var pets = _service.PetService.GetPets(ownerId, trackChanges: false);
			return Ok(pets);
        }

		[HttpGet("{id:guid}")]
		public IActionResult GetPetForOwner(Guid ownerId, Guid id)
        {
			var pet = _service.PetService.GetPet(ownerId, id, trackChanges: false);
			return Ok(pet);
        }
	}
}

