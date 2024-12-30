using MediaVisualizer.Services;
using MediaVisualizer.Shared.Dtos;
using MediaVisualizer.Shared.Requests;
using Microsoft.AspNetCore.Mvc;

namespace MediaVisualizer.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ManwhaController : ControllerBase
    {
        private readonly IManwhaService _manwhaService;

        public ManwhaController(IManwhaService manwhaService)
        {
            _manwhaService = manwhaService;
        }

        [HttpGet]
        [Route("{key:int}")]
        public async Task<IActionResult> Get(int key)
        {
            var manwha = await _manwhaService.Get(key);
            return Ok(manwha);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetList([FromQuery] FiltersRequest filters)
        {
            var manwhas = await _manwhaService.GetList(filters);
            return Ok(manwhas);
        }
    }
}