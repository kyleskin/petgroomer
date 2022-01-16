using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public IActionResult GetGroomersInSalon(Guid salonId)
        {
            var groomers = _service.GroomerService.GetGroomers(salonId, trackChanges: false);
            return Ok(groomers);
        }

        [HttpGet("{id:guid}", Name = "GetGroomerInSalon")]
        public IActionResult GetGroomerInSalon(Guid salonId, Guid id)
        {
            var groomer = _service.GroomerService.GetGroomer(salonId, id, trackChanges: false);
            return Ok(groomer);
        }

        [HttpPost]
        public IActionResult CreateGroomerInSalon(Guid salonId, [FromBody] GroomerForCreationDto groomer)
        {
            if (groomer is null)
                return BadRequest("GroomerForCreationDto is null.");

            var groomerToReturn = _service.GroomerService.CreateGroomerInSalon(salonId, groomer, trackChages: false);

            return CreatedAtRoute("GetGroomerInSalon", new { salonId, id = groomerToReturn.Id }, groomerToReturn);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteGroomerFromSalon(Guid salonId, Guid id)
        {
            _service.GroomerService.DeleteGroomerFromSalon(salonId, id, trackChages: false);

            return NoContent();
        }
    }
}