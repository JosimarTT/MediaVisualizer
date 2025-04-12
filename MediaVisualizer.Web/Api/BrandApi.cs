using MediaVisualizer.Services.Dtos;

namespace MediaVisualizer.Web.Api;

public class BrandApi : IBrandApi
{
    private const string BaseUrl = "Brand";
    private readonly HttpClient _httpClient;

    public BrandApi(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public Task<List<BrandDto>> GetListAsync()
    {
        return _httpClient.GetFromJsonAsync<List<BrandDto>>($"{BaseUrl}/GetList");
    }
}

public interface IBrandApi
{
    Task<List<BrandDto>> GetListAsync();
}