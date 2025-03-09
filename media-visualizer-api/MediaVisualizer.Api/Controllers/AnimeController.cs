using MediaVisualizer.Services;
using MediaVisualizer.Services.Dtos;
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
    [Route("~/[controller]/{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        return Ok(await _animeService.Get(id));
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
    public async Task<IActionResult> SearchNew()
    {
        return Ok(await _animeService.SearchNew());
    }

    [HttpGet]
    public async Task<IActionResult> GetTitles()
    {
        return Ok(await _animeService.GetTitles());
    }

    [HttpPost]
    [Route("~/[controller]")]
    public async Task<IActionResult> Add([FromBody] AnimeDto anime)
    {
        return Ok(await _animeService.Add(anime));
    }

    [HttpPut]
    [Route("~/[controller]")]
    public async Task<IActionResult> Update([FromQuery] int animeId, [FromBody] AnimeDto anime,
        CancellationToken cancellationToken)
    {
        return Ok(await _animeService.Update(animeId, anime, cancellationToken));
    }
}