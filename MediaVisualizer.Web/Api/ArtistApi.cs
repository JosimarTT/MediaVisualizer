using MediaVisualizer.Services.Dtos;

namespace MediaVisualizer.Web.Api;

public class ArtistApi : IArtistApi
{
    private readonly HttpClient _httpClient;

    public ArtistApi(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public Task<List<ArtistDto>> GetList()
    {
        return _httpClient.GetFromJsonAsync<List<ArtistDto>>("api/Artist/GetList");
    }
}

public interface IArtistApi
{
    Task<List<ArtistDto>> GetList();
}