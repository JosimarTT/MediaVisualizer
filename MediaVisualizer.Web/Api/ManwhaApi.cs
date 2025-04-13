using MediaVisualizer.Shared.Dtos;
using MediaVisualizer.Shared.Requests;
using MediaVisualizer.Shared.Responses;
using MediaVisualizer.Web.Helpers;

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

    public Task<ListResponse<ManwhaDto>> GetListAsync(FiltersRequest filters)
    {
        var query = FiltersRequestHelper.BuildFiltersRequest(filters);
        return _httpClient.GetFromJsonAsync<ListResponse<ManwhaDto>>($"{BaseUrl}/GetList?{query}");
    }
}

public interface IManwhaApi
{
    Task<ManwhaDto> GetAsync(int manwhaId);
    Task<ListResponse<ManwhaDto>> GetListAsync(FiltersRequest filters);
    Task<ManwhaDto> GetRandomAsync();
    Task<List<string>> GetTitlesAsync();
}