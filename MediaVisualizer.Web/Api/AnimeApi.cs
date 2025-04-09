using MediaVisualizer.Services.Dtos;
using MediaVisualizer.Shared.Requests;
using MediaVisualizer.Shared.Responses;
using MediaVisualizer.Web.Helpers;

namespace MediaVisualizer.Web.Api;

public class AnimeApi : IAnimeApi
{
    private const string BaseUrl = "Anime";
    private readonly HttpClient _httpClient;

    public AnimeApi(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public Task<AnimeDto> GetAsync(int animeId)
    {
        return _httpClient.GetFromJsonAsync<AnimeDto>($"{BaseUrl}/{animeId}");
    }

    public Task<AnimeDto> GetRandomAsync()
    {
        return _httpClient.GetFromJsonAsync<AnimeDto>($"{BaseUrl}/GetRandom");
    }

    public Task<ListResponse<AnimeDto>> GetListAsync(FiltersRequest filters)
    {
        var query = FiltersRequestHelper.BuildFiltersRequest(filters);
        return _httpClient.GetFromJsonAsync<ListResponse<AnimeDto>>($"{BaseUrl}/GetList?{query}");
    }

    public Task<List<string>> GetTitlesAsync()
    {
        return _httpClient.GetFromJsonAsync<List<string>>($"{BaseUrl}/GetTitles");
    }
}

public interface IAnimeApi
{
    Task<AnimeDto> GetAsync(int animeId);
    Task<AnimeDto> GetRandomAsync();
    Task<ListResponse<AnimeDto>> GetListAsync(FiltersRequest filters);
    Task<List<string>> GetTitlesAsync();
}