using Microsoft.AspNetCore.Mvc;
using SupportWebApp.Server.Services;
using SupportWebApp.Shared.Modeller;

namespace SupportWebApp.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SupportController : ControllerBase
    {
        private readonly CosmosService _cosmosService;

        public SupportController(CosmosService cosmosService)
        {
            _cosmosService = cosmosService;
        }

        // POST: api/support
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SupportHenvendelse item)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _cosmosService.AddHenvendelse(item);
            return Ok(new { message = "Supporthenvendelse oprettet." });
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _cosmosService.HentAlleHenvendelser();
            return Ok(data);
        }

    }
}