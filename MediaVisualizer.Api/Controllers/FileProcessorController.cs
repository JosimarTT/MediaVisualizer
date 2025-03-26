using MediaVisualizer.Shared;
using MediaVisualizer.Shared.ExtensionMethods;
using Microsoft.AspNetCore.Mvc;

namespace MediaVisualizer.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class FileProcessorController : ControllerBase
{
    private readonly ILogger<FileProcessorController> _logger;

    public FileProcessorController(ILogger<FileProcessorController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> StreamVideo([FromQuery] string path)
    {
        var filePath = Path.Combine(StringConstants.AnimeCollectionPath, path);

        if (!System.IO.File.Exists(filePath))
        {
            _logger.LogWarning("File not found: {FilePath}", filePath);
            return NotFound();
        }

        var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, true);
        return new FileStreamResult(fileStream, "video/mp4")
        {
            EnableRangeProcessing = true
        };
    }

    [HttpGet]
    public async Task<IActionResult> ProcessImage([FromQuery] string filePath, [FromQuery] double? percentage)
    {
        _logger.LogInformation("Processing image: {FilePath} with percentage: {Percentage}", filePath, percentage);
        return Ok(await filePath.ResizeImageToBase64(percentage));
    }

    [HttpGet]
    public async Task<IActionResult> ProcessImageV2([FromQuery] string filePath, [FromQuery] double? percentage)
    {
        _logger.LogInformation("Processing image: {FilePath} with percentage: {Percentage}", filePath, percentage);

        var imagePath = Path.Combine(StringConstants.MangaCollectionPath, filePath);
        if (!System.IO.File.Exists(imagePath))
        {
            _logger.LogWarning("File not found: {FilePath}", imagePath);
            return NotFound();
        }

        var resizedImageStream = await filePath.ResizeImageToStream(percentage);
        return new FileStreamResult(resizedImageStream, "image/jpeg");
    }
}