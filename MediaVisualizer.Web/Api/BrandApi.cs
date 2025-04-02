using MediaVisualizer.Services.Dtos;

namespace MediaVisualizer.Web.Api;

public class BrandApi : IBrandApi
{
    private readonly HttpClient _httpClient;

    public BrandApi(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public Task<List<BrandDto>> GetList()
    {
        return _httpClient.GetFromJsonAsync<List<BrandDto>>("Brand/GetList");
    }
}

public interface IBrandApi
{
    Task<List<BrandDto>> GetList();
}