using System;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

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

		[HttpGet("{id:guid}", Name = "OwnerById")]
		public IActionResult GetOwner(Guid id)
        {
			var owner = _service.OwnerService.GetOwner(id, trackChanges: false);
			return Ok(owner);
        }

		[HttpPost]
		public IActionResult CreateOwner([FromBody] OwnerForCreationDto owner)
        {
			if (owner is null)
				return BadRequest("OwnerForCreationDto object is null.");

			var createdOwner = _service.OwnerService.CreateOwner(owner);

			return CreatedAtRoute("OwnerById", new { id = createdOwner.Id }, createdOwner);
        }
	}
}

