using System;
using Microsoft.AspNetCore.JsonPatch;
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

		[HttpGet("{id:guid}", Name = "GetPetForOwner")]
		public IActionResult GetPetForOwner(Guid ownerId, Guid id)
        {
			var pet = _service.PetService.GetPet(ownerId, id, trackChanges: false);
			return Ok(pet);
        }

		[HttpPost]
		public IActionResult CreatePetForOwner(Guid ownerId, [FromBody] PetForCreationDto pet)
        {
			if (pet is null)
				return BadRequest("PetForCreationDto object is null.");

			var petToReturn = _service.PetService.CreatePetForOwner(ownerId, pet, trackChanges: false);

			return CreatedAtRoute("GetPetForOwner", new { ownerId, id = petToReturn.Id }, petToReturn);
        }

		[HttpDelete("{id:guid}")]
		public IActionResult DeletePetForOwner(Guid ownerId, Guid id)
		{
			_service.PetService.DeletePetForOwner(ownerId, id, trackChanges: false);

			return NoContent();
		}

		[HttpPut("{id:guid}")]
		public IActionResult UpdatePetForOwner(Guid ownerId, Guid id, [FromBody] PetForUpdateDto pet)
		{
			if (pet is null)
				return BadRequest("PetForUpdate object is null.");
			
			_service.PetService.UpdatePetForOwner(ownerId, id, pet, ownerTrackChanges: false, petTrackChanges: true);

			return NoContent();
		}

		[HttpPatch("{id:guid}")]
		public IActionResult PartiallyUpdatePetForOwner(Guid ownerId, Guid id, [FromBody] JsonPatchDocument<PetForUpdateDto> patchDoc)
		{
			if (patchDoc is null)
				return BadRequest("patchDoc object sent from client is null.");

			var result = _service.PetService.GetPetForPatch(ownerId, id, ownerTrackChanges: false, petTrackChanges: true);

			patchDoc.ApplyTo(result.petToPatch);

			_service.PetService.SaveChangesForPatch(result.petToPatch, result.petEntity);

			return NoContent();
		}
	}
}
