using MediaVisualizer.Services;
using MediaVisualizer.Services.Dtos;
using MediaVisualizer.Shared.Requests;
using Microsoft.AspNetCore.Mvc;

namespace MediaVisualizer.Api.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class MangaController : ControllerBase
{
    private readonly IMangaService _mangaService;

    public MangaController(IMangaService mangaService)
    {
        _mangaService = mangaService;
    }

    [HttpGet]
    [Route("~/api/[controller]/{id:int}")]
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
    public async Task<ActionResult<MangaDto>> GetRandom()
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
    [Route("~/api/[controller]")]
    public async Task<IActionResult> Add([FromBody] MangaDto manga)
    {
        return Ok(await _mangaService.Add(manga));
    }

    [HttpGet("page")]
    public async Task<IActionResult> GetMangaPage([FromQuery] string folder, [FromQuery] int page,
        [FromQuery] string extension)
    {
        var mangaDto = new MangaDto
        {
            Folder = folder,
            PagesCount = 0, // This value is not used in GetMangaPage
            PageExtension = extension
        };

        var mangaPage = await _mangaService.GetMangaPage(mangaDto, page);
        if (string.IsNullOrEmpty(mangaPage)) return NotFound();
        return Ok(mangaPage);
    }
}