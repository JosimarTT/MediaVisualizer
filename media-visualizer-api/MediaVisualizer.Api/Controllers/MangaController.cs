using MediaVisualizer.Services;
using MediaVisualizer.Shared.Dtos;
using MediaVisualizer.Shared.Requests;
using Microsoft.AspNetCore.Mvc;

namespace MediaVisualizer.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class MangaController : ControllerBase
{
    private readonly IMangaService _mangaService;

    public MangaController(IMangaService mangaService)
    {
        _mangaService = mangaService;
    }

    [HttpGet]
    [Route("{key:int}")]
    public async Task<IActionResult> Get(int key)
    {
        return Ok(await _mangaService.Get(key));
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] FiltersRequest filters)
    {
        return Ok(await _mangaService.GetList(filters));
    }

    [HttpGet]
    public async Task<IActionResult> GetRandom()
    {
        return Ok(await _mangaService.GetRandom());
    }

    [HttpGet]
    public async Task<IActionResult> Migrate()
    {
        await _mangaService.Migrate();
        return Ok();
    }
}