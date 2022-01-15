using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

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
    }
}