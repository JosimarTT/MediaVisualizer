using MediaVisualizer.Services;
using MediaVisualizer.Services.Dtos;
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
    [Route("~/[controller]/{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        return Ok(await _mangaService.Get(id));
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
    public async Task<IActionResult> GetTitles()
    {
        return Ok(await _mangaService.GetTitles());
    }

    [HttpGet]
    public async Task<IActionResult> GetTitlesToAdd()
    {
        return Ok(await _mangaService.GetTitlesToAdd());
    }

    [HttpPost]
    [Route("~/[controller]")]
    public async Task<IActionResult> Add([FromBody] MangaDto manga)
    {
        return Ok(await _mangaService.Add(manga));
    }
}