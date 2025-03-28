using MediaVisualizer.Services.Dtos;
using MediaVisualizer.Shared.Requests;
using MediaVisualizer.Shared.Responses;
using MediaVisualizer.Web.Helpers;

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
        return _httpClient.GetFromJsonAsync<AnimeDto>("Anime/GetRandom");
    }

    public Task<ListResponse<AnimeDto>> GetList(FiltersRequest filters)
    {
        var query = FiltersRequestHelper.BuildFilterRequest(filters);
        return _httpClient.GetFromJsonAsync<ListResponse<AnimeDto>>($"Anime/GetList?{query}");
    }
}

public interface IAnimeApi
{
    Task<AnimeDto> Get(int animeId);
    Task<AnimeDto> GetRandom();
    Task<ListResponse<AnimeDto>> GetList(FiltersRequest filters);
}