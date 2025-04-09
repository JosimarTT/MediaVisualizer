using MediaVisualizer.Services.Dtos;

namespace MediaVisualizer.Web.Api;

public class ArtistApi : IArtistApi
{
    private const string BaseUrl = "Artist";
    private readonly HttpClient _httpClient;

    public ArtistApi(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public Task<List<ArtistDto>> GetListAsync()
    {
        return _httpClient.GetFromJsonAsync<List<ArtistDto>>($"{BaseUrl}/GetList");
    }
}

public interface IArtistApi
{
    Task<List<ArtistDto>> GetListAsync();
}