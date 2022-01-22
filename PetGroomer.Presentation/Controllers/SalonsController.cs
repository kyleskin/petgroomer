using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        public async Task<IActionResult> GetSalon(Guid id)
        {
            var salon = await _service.SalonService.GetSalonAsync(id, trackChanges: false);
            return Ok(salon);
        }
    }
}