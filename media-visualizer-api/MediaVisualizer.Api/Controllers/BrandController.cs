using MediaVisualizer.Services;
using Microsoft.AspNetCore.Mvc;

namespace MediaVisualizer.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class BrandController:ControllerBase
{
    private readonly IBrandService _artistService;

    public BrandController(IBrandService artistService)
    {
        _artistService = artistService;
    }

    [HttpGet]
    public async Task<IActionResult> GetList()
    {
        return Ok(await _artistService.GetList());
    }
}