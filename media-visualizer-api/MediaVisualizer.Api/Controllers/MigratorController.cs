using MediaVisualizer.Services;
using Microsoft.AspNetCore.Mvc;

namespace MediaVisualizer.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class MigratorController : ControllerBase
{
    private readonly ISeedMigratorService _seedMigratorService;

    public MigratorController(ISeedMigratorService seedMigratorService)
    {
        _seedMigratorService = seedMigratorService;
    }

    [HttpPost]
    public async Task<IActionResult> Migrate()
    {
        await _seedMigratorService.Migrate();
        return Ok();
    }
}