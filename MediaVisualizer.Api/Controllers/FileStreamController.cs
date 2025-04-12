using MediaVisualizer.Shared.ExtensionMethods;
using MediaVisualizer.Shared.Requests;
using Microsoft.AspNetCore.Mvc;

namespace MediaVisualizer.Api.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class FileStreamController : ControllerBase
{
    private readonly ILogger<FileStreamController> _logger;

    public FileStreamController(ILogger<FileStreamController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> StreamVideo([FromQuery] string filePath)
    {
        if (!System.IO.File.Exists(filePath))
        {
            _logger.LogError("File not found: {FilePath}", filePath);
            return NotFound();
        }

        var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, true);
        return new FileStreamResult(fileStream, "video/mp4")
        {
            EnableRangeProcessing = true
        };
    }

    [HttpGet]
    public async Task<IActionResult> StreamImage([FromQuery] ImageRequest request)
    {
        _logger.LogInformation("Processing image: {FilePath} with width: {Width} and height: {Height}",
            request.FilePath, request.Width, request.Height);

        var decodedFilePath = Uri.UnescapeDataString(request.FilePath);
        if (!System.IO.File.Exists(decodedFilePath))
        {
            _logger.LogError("File not found: {FilePath}", decodedFilePath);
            return NotFound();
        }

        var resizedImageStream = await decodedFilePath.ResizeImageToStream(request.Width, request.Height);
        return new FileStreamResult(resizedImageStream, "image/jpeg");
    }
}