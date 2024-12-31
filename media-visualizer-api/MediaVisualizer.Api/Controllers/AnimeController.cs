using MediaVisualizer.DataAccess.Entities.Anime;
using MediaVisualizer.Services;
using MediaVisualizer.Shared.Dtos;
using MediaVisualizer.Shared.Requests;
using Microsoft.AspNetCore.Mvc;

namespace MediaVisualizer.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class AnimeController : ControllerBase
{
    private readonly IAnimeService _animeService;

    public AnimeController(IAnimeService animeService)
    {
        _animeService = animeService;
    }

    [HttpGet]
    [Route("{key:int}")]
    public async Task<IActionResult> Get(int key)
    {
        return Ok(await _animeService.Get(key));
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] FiltersRequest filters)
    {
        return Ok(await _animeService.GetList(filters));
    }

    [HttpGet]
    public async Task<IActionResult> GetRandom()
    {
        return Ok(await _animeService.GetRandom());
    }

    [HttpGet]
    public async Task<IActionResult> Migrate()
    {
        await _animeService.Migrate();
        return Ok();
    }
}