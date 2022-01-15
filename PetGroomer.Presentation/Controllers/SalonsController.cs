using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace PetGroomer.Presentation.Controllers
{
    [Route("api/salons")]
    [ApiController]
    public class SalonsController : ControllerBase
    {
        private readonly IServiceManager _service;

        public SalonsController(IServiceManager service) => _service = service;

        
        [HttpGet("{id:guid}", Name = "SalonById")]
        public IActionResult GetSalon(Guid id)
        {
            var salon = _service.SalonService.GetSalon(id, trackChanges: false);
            return Ok(salon);
        }
    }
}