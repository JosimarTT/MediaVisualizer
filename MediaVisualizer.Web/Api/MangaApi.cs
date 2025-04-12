using MediaVisualizer.Services.Dtos;
using MediaVisualizer.Shared.Requests;
using MediaVisualizer.Shared.Responses;
using MediaVisualizer.Web.Helpers;

namespace MediaVisualizer.Web.Api;

public class MangaApi : IMangaApi
{
    private const string BaseUrl = "Manga";
    private readonly HttpClient _httpClient;

    public MangaApi(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public Task<MangaDto> GetAsync(int mangaId)
    {
        return _httpClient.GetFromJsonAsync<MangaDto>($"{BaseUrl}/{mangaId}");
    }

    public Task<MangaDto> GetRandomAsync()
    {
        return _httpClient.GetFromJsonAsync<MangaDto>($"{BaseUrl}/GetRandom");
    }

    public Task<ListResponse<MangaDto>> GetListAsync(FiltersRequest filters)
    {
        var query = FiltersRequestHelper.BuildFiltersRequest(filters);
        return _httpClient.GetFromJsonAsync<ListResponse<MangaDto>>($"{BaseUrl}/GetList?{query}");
    }

    public Task<List<string>> GetTitlesAsync()
    {
        return _httpClient.GetFromJsonAsync<List<string>>($"{BaseUrl}/GetTitles");
    }
}

public interface IMangaApi
{
    Task<MangaDto> GetAsync(int mangaId);
    Task<MangaDto> GetRandomAsync();
    Task<ListResponse<MangaDto>> GetListAsync(FiltersRequest filters);
    Task<List<string>> GetTitlesAsync();
}