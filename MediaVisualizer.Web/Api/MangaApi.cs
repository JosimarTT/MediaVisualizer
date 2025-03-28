using MediaVisualizer.Services.Dtos;
using MediaVisualizer.Shared.Requests;
using MediaVisualizer.Shared.Responses;
using MediaVisualizer.Web.Helpers;

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

    public Task<ListResponse<MangaDto>> GetList(FiltersRequest filters)
    {
        var query = FiltersRequestHelper.BuildFiltersRequest(filters);
        return _httpClient.GetFromJsonAsync<ListResponse<MangaDto>>($"Manga/GetList?{query}");
    }
}

public interface IMangaApi
{
    Task<MangaDto> Get(int mangaId);
    Task<MangaDto> GetRandom();
    Task<ListResponse<MangaDto>> GetList(FiltersRequest filters);
}