using MediaVisualizer.Services.Dtos;
using MediaVisualizer.Web.Helpers;

namespace MediaVisualizer.Web.Api;

public class ArtistApi : IArtistApi
{
    private readonly HttpClient _httpClient;
    private readonly PersistentDataHelper _persistentDataHelper;

    public ArtistApi(HttpClient httpClient, PersistentDataHelper persistentDataHelper)
    {
        _httpClient = httpClient;
        _persistentDataHelper = persistentDataHelper;
    }

    public Task<List<ArtistDto>> GetList()
    {
        return _persistentDataHelper.Artists.Count > 0
            ? Task.FromResult(_persistentDataHelper.Artists.ToList())
            : _httpClient.GetFromJsonAsync<List<ArtistDto>>("Artist/GetList");
    }
}

public interface IArtistApi
{
    Task<List<ArtistDto>> GetList();
}