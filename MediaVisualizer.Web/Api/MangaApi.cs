using MediaVisualizer.Services.Dtos;

namespace MediaVisualizer.Web.Api;

public class MangaApi : IMangaApi
{
    private readonly HttpClient _httpClient;

    public MangaApi(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public Task<MangaDto> Get(int mangaId)
    {
        return _httpClient.GetFromJsonAsync<MangaDto>($"Manga/{mangaId}");
    }

    public Task<MangaDto> GetRandom()
    {
        return _httpClient.GetFromJsonAsync<MangaDto>("Manga/GetRandom");
    }
}

public interface IMangaApi
{
    Task<MangaDto> Get(int mangaId);
    Task<MangaDto> GetRandom();
}