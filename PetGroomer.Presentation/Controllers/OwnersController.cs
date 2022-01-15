using System;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace PetGroomer.Presentation.Controllers
{
	[Route("api/salons/{salonId}/owners")]
	[ApiController]
	public class OwnersController : ControllerBase
	{
		private readonly IServiceManager _service;

		public OwnersController(IServiceManager service) => _service = service;

		[HttpGet]
		public IActionResult GetOwners(Guid salonId)
        {
			var owners = _service.OwnerService.GetOwners(salonId, trackChanges: false);

			return Ok(owners);
		}

		[HttpGet("{ownerId:guid}", Name = "OwnerById")]
		public IActionResult GetOwner(Guid salonId, Guid ownerId)
        {
			var owner = _service.OwnerService.GetOwner(salonId, ownerId, trackChanges: false);
			return Ok(owner);
        }

		[HttpPost]
		public IActionResult CreateOwner(Guid salonId, [FromBody] OwnerForCreationDto owner)
        {
			if (owner is null)
				return BadRequest("OwnerForCreationDto object is null.");

			var createdOwner = _service.OwnerService.CreateOwner(salonId, owner);

			return CreatedAtRoute("OwnerById", new { salonId, ownerId = createdOwner.Id }, createdOwner);
        }

		[HttpDelete("{id:guid}")]
		public IActionResult DeleteOwner(Guid salonId, Guid id)
		{
			_service.OwnerService.DeleteOwner(salonId, id, trackChanges: false);

			return NoContent();
		}

		[HttpPut("{id:guid}")]
		public IActionResult UpdateOwner(Guid salonId, Guid id, [FromBody] OwnerForUpdateDto owner)
		{
			if (owner is null)
				return BadRequest("OwnerForUpdate object is null.");

			_service.OwnerService.UpdateOwner(salonId, id, owner, trackChanges: true);

			return NoContent();
		}
	}
}

