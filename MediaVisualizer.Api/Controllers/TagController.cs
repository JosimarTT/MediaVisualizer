using MediaVisualizer.Services;
using Microsoft.AspNetCore.Mvc;

namespace MediaVisualizer.Api.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class TagController : ControllerBase
{
    private readonly ITagService _artistService;

    public TagController(ITagService artistService)
    {
        _artistService = artistService;
    }

    [HttpGet]
    public async Task<IActionResult> GetList()
    {
        return Ok(await _artistService.GetList());
    }
}