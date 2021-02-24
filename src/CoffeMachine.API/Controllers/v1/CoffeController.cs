using CoffeMachine.Domain.Entities;
using CoffeMachine.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoffeMachine.API.Controllers.V1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CoffeController : ControllerBase
    {
        private readonly ICoffeService _coffeService;

        public CoffeController(ICoffeService coffeService)
        {
            _coffeService = coffeService;
        }

        [ProducesResponseType(typeof(List<Coffe>), 200)]
        [ProducesResponseType(204)]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _coffeService.Get();
            if (result is null) return NoContent();
            return Ok(await _coffeService.Get());
        }
    }
}
