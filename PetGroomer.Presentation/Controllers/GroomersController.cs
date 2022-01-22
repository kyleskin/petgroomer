using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace PetGroomer.Presentation.Controllers
{
    [Route("api/salons/{salonId}/groomers")]
    [ApiController]
    public class GroomersController : ControllerBase
    {
        private readonly IServiceManager _service;

        public GroomersController(IServiceManager service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetGroomersInSalon(Guid salonId)
        {
            var groomers = await _service.GroomerService.GetGroomersAsync(salonId, trackChanges: false);
            return Ok(groomers);
        }

        [HttpGet("{id:guid}", Name = "GetGroomerInSalon")]
        public async Task<IActionResult> GetGroomerInSalon(Guid salonId, Guid id)
        {
            var groomer = await _service.GroomerService.GetGroomerAsync(salonId, id, trackChanges: false);
            return Ok(groomer);
        }

        [HttpPost]
        public async Task<IActionResult> CreateGroomerInSalon(Guid salonId, [FromBody] GroomerCreationDto groomer)
        {
            if (groomer is null)
                return BadRequest("GroomerForCreationDto is null.");

            var groomerToReturn = await _service.GroomerService.CreateGroomerInSalonAsync(salonId, groomer, trackChages: false);

            return CreatedAtRoute("GetGroomerInSalon", new { salonId, id = groomerToReturn.Id }, groomerToReturn);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteGroomerFromSalon(Guid salonId, Guid id)
        {
            await _service.GroomerService.DeleteGroomerFromSalonAsync(salonId, id, trackChages: false);

            return NoContent();
        }
    }
}