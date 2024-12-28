using MediaVisualizer.Services;
using MediaVisualizer.Shared.Dtos;
using MediaVisualizer.Shared.Requests;
using Microsoft.AspNetCore.Mvc;

namespace MediaVisualizer.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class MangaController : ControllerBase
{
    private readonly IMangaService _mangaService;

    public MangaController(IMangaService mangaService)
    {
        _mangaService = mangaService;
    }

    [HttpGet]
    [Route("{key:int}")]
    public async Task<MangaDto> Get(int key)
    {
        return await _mangaService.Get(key);
    }

    [HttpGet]
    [Route("[action]")]
    public async Task<IActionResult> GetList([FromQuery] FiltersRequest filters)
    {
        var mangas = await _mangaService.GetList(filters);
        return Ok(mangas);
    }
}