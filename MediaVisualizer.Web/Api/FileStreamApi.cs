namespace MediaVisualizer.Web.Api;

public class FileStreamApi : IFileStreamApi
{
    private readonly HttpClient _httpClient;

    public FileStreamApi(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public string GetStreamVideoPath(string[] paths)
    {
        var filePath = Path.Combine(paths[0]);
        var encodedFilePath = Uri.EscapeDataString(filePath);
        return $"{_httpClient.BaseAddress}FileStream/StreamVideo?filePath={encodedFilePath}";
    }

    public string GetStreamImagePath(string[] paths, double? percentage = null)
    {
        var filePath = Path.Combine(paths[0]);
        var encodedFilePath = Uri.EscapeDataString(filePath);
        var percentageQuery = percentage.HasValue ? $"&percentage={percentage.Value}" : string.Empty;
        return $"{_httpClient.BaseAddress}FileStream/StreamImage?filePath={encodedFilePath}{percentageQuery}";
    }
}

public interface IFileStreamApi
{
    string GetStreamVideoPath(string[] paths);
    string GetStreamImagePath(string[] paths, double? percentage = null);
}