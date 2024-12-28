using MediaVisualizer.DataAccess.Entities.Anime;
using MediaVisualizer.Services;
using MediaVisualizer.Shared.Dtos;
using MediaVisualizer.Shared.Requests;
using Microsoft.AspNetCore.Mvc;

namespace MediaVisualizer.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AnimeController : ControllerBase
{
    private readonly IAnimeService _animeService;

    public AnimeController(IAnimeService animeService)
    {
        _animeService = animeService;
    }

    [HttpGet]
    [Route("{key:int}")]
    public async Task<AnimeDto> Get(int key)
    {
        return await _animeService.Get(key);
    }

    [HttpGet]
    [Route("[action]")]
    public async Task<IActionResult> GetList([FromQuery] FiltersRequest filters)
    {
        var animes = await _animeService.GetList(filters);
        return Ok(animes);
    }
}