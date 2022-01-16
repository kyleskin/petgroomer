using System;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace PetGroomer.Presentation.Controllers
{
	[Route("api/salons/{salonId}/owners/{ownerId}/pets")]
	[ApiController]
	public class PetsController : ControllerBase
	{
		private readonly IServiceManager _service;

		public PetsController(IServiceManager service) => _service = service;

		[HttpGet]
		public async Task<IActionResult> GetPetsForOwner(Guid salonId, Guid ownerId)
        {
			var pets = await _service.PetService.GetPetsAsync(salonId, ownerId, trackChanges: false);
			return Ok(pets);
        }

		[HttpGet("{id:guid}", Name = "GetPetForOwner")]
		public async Task<IActionResult> GetPetForOwner(Guid salonId, Guid ownerId, Guid id)
        {
			var pet = await _service.PetService.GetPetAsync(salonId, ownerId, id, trackChanges: false);
			return Ok(pet);
        }

		[HttpPost]
		public async Task<IActionResult> CreatePetForOwner(Guid salonId, Guid ownerId, [FromBody] PetForCreationDto pet)
        {
			if (pet is null)
				return BadRequest("PetForCreationDto object is null.");

			var petToReturn = await _service.PetService.CreatePetForOwnerAsync(salonId, ownerId, pet, trackChanges: false);

			return CreatedAtRoute("GetPetForOwner", new { salonId, ownerId, id = petToReturn.Id }, petToReturn);
        }

		[HttpDelete("{id:guid}")]
		public async Task<IActionResult> DeletePetForOwner(Guid salonId, Guid ownerId, Guid id)
		{
			await _service.PetService.DeletePetForOwnerAsync(salonId, ownerId, id, trackChanges: false);

			return NoContent();
		}

		[HttpPut("{id:guid}")]
		public async Task<IActionResult> UpdatePetForOwner(Guid salonId, Guid ownerId, Guid id, [FromBody] PetForUpdateDto pet)
		{
			if (pet is null)
				return BadRequest("PetForUpdate object is null.");
			
			await _service.PetService.UpdatePetForOwnerAsync(salonId, ownerId, id, pet, ownerTrackChanges: false, petTrackChanges: true);

			return NoContent();
		}

		[HttpPatch("{id:guid}")]
		public async Task<IActionResult> PartiallyUpdatePetForOwner(Guid salonId, Guid ownerId, Guid id, [FromBody] JsonPatchDocument<PetForUpdateDto> patchDoc)
		{
			if (patchDoc is null)
				return BadRequest("patchDoc object sent from client is null.");

			var result = await _service.PetService.GetPetForPatchAsync(salonId, ownerId, id, ownerTrackChanges: false, petTrackChanges: true);

			patchDoc.ApplyTo(result.petToPatch);

			await _service.PetService.SaveChangesForPatchAsync(result.petToPatch, result.petEntity);

			return NoContent();
		}
	}
}
