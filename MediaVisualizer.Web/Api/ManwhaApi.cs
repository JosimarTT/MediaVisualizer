using MediaVisualizer.Shared.Dtos;

namespace MediaVisualizer.Web.Api;

public class ManwhaApi : IManwhaApi
{
    private const string BaseUrl = "Manwha";
    private readonly HttpClient _httpClient;

    public ManwhaApi(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public Task<ManwhaDto> GetAsync(int manwhaId)
    {
        return _httpClient.GetFromJsonAsync<ManwhaDto>($"{BaseUrl}/{manwhaId}");
    }

    public Task<ManwhaDto> GetRandomAsync()
    {
        return _httpClient.GetFromJsonAsync<ManwhaDto>($"{BaseUrl}/GetRandom");
    }

    public Task<List<string>> GetTitlesAsync()
    {
        return _httpClient.GetFromJsonAsync<List<string>>($"{BaseUrl}/GetTitles");
    }
}

public interface IManwhaApi
{
    Task<ManwhaDto> GetAsync(int manwhaId);
    Task<ManwhaDto> GetRandomAsync();
    Task<List<string>> GetTitlesAsync();
}