using MediaVisualizer.DataAccess.Entities.Anime;
using MediaVisualizer.Services;
using MediaVisualizer.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace MediaVisualizer.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AnimeController:ControllerBase
{
    private readonly IAnimeService _animeService;

    public AnimeController(IAnimeService animeService)
    {
        _animeService = animeService;
    }

    [HttpGet]
    public async Task<IEnumerable<AnimeDto>> Get()
    {
        return await _animeService.GetAll();
    }
}