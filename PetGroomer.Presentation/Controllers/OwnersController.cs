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
		public async Task<IActionResult> GetOwners(Guid salonId)
        {
			var owners = await _service.OwnerService.GetOwnersAsync(salonId, trackChanges: false);

			return Ok(owners);
		}

		[HttpGet("{ownerId:guid}", Name = "OwnerById")]
		public async Task<IActionResult> GetOwner(Guid salonId, Guid ownerId)
        {
			var owner = await _service.OwnerService.GetOwnerAsync(salonId, ownerId, trackChanges: false);
			return Ok(owner);
        }

		[HttpPost]
		public async Task<IActionResult> CreateOwner(Guid salonId, [FromBody] OwnerForCreationDto owner)
        {
			if (owner is null)
				return BadRequest("OwnerForCreationDto object is null.");

			var createdOwner = await _service.OwnerService.CreateOwnerAsync(salonId, owner);

			return CreatedAtRoute("OwnerById", new { salonId, ownerId = createdOwner.Id }, createdOwner);
        }

		[HttpDelete("{id:guid}")]
		public async Task<IActionResult> DeleteOwner(Guid salonId, Guid id)
		{
			await _service.OwnerService.DeleteOwnerAsync(salonId, id, trackChanges: false);

			return NoContent();
		}

		[HttpPut("{id:guid}")]
		public async Task<IActionResult> UpdateOwner(Guid salonId, Guid id, [FromBody] OwnerForUpdateDto owner)
		{
			if (owner is null)
				return BadRequest("OwnerForUpdate object is null.");

			await _service.OwnerService.UpdateOwnerAsync(salonId, id, owner, trackChanges: true);

			return NoContent();
		}
	}
}

