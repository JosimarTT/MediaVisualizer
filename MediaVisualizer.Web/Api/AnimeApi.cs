using MediaVisualizer.Services.Dtos;

namespace MediaVisualizer.Web.Api;

public class AnimeApi : IAnimeApi
{
    private readonly HttpClient _httpClient;

    public AnimeApi(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public Task<AnimeDto> Get(int animeId)
    {
        return _httpClient.GetFromJsonAsync<AnimeDto>($"Anime/{animeId}");
    }

    public Task<AnimeDto> GetRandom()
    {
        var fullUrl = new Uri(_httpClient.BaseAddress, "Anime/GetRandom");
        Console.WriteLine(fullUrl);
        return _httpClient.GetFromJsonAsync<AnimeDto>("Anime/GetRandom");
    }
}

public interface IAnimeApi
{
    Task<AnimeDto> Get(int animeId);
    Task<AnimeDto> GetRandom();
}