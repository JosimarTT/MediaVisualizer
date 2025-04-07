using MediaVisualizer.Shared.Requests;
using MediaVisualizer.Web.Helpers;

namespace MediaVisualizer.Web.Api;

public class FileStreamApi : IFileStreamApi
{
    private readonly HttpClient _httpClient;

    public FileStreamApi(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public string GetStreamVideoPath(string filePath)
    {
        var encodedFilePath = Uri.EscapeDataString(filePath);
        return $"{_httpClient.BaseAddress}FileStream/StreamVideo?filePath={encodedFilePath}";
    }

    public string GetStreamImagePath(string filePath, int? width = null, int? height = null)
    {
        var encodedFilePath = Uri.EscapeDataString(filePath);
        var filters = new ImageRequest
        {
            FilePath = encodedFilePath,
            Width = width,
            Height = height
        };
        var query = FiltersRequestHelper.BuildImageRequest(filters);
        return $"{_httpClient.BaseAddress}FileStream/StreamImage?{query}";
    }
}

public interface IFileStreamApi
{
    string GetStreamVideoPath(string filePath);
    string GetStreamImagePath(string filePath, int? width = null, int? height = null);
}