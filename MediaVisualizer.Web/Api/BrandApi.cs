using MediaVisualizer.Services.Dtos;
using MediaVisualizer.Web.Helpers;

namespace MediaVisualizer.Web.Api;

public class BrandApi : IBrandApi
{
    private readonly HttpClient _httpClient;
    private readonly PersistentDataHelper _persistentDataHelper;

    public BrandApi(HttpClient httpClient, PersistentDataHelper persistentDataHelper)
    {
        _httpClient = httpClient;
        _persistentDataHelper = persistentDataHelper;
    }

    public Task<List<BrandDto>> GetList()
    {
        return _persistentDataHelper.Brands.Count > 0
            ? Task.FromResult(_persistentDataHelper.Brands.ToList())
            : _httpClient.GetFromJsonAsync<List<BrandDto>>("Brand/GetList");
    }
}

public interface IBrandApi
{
    Task<List<BrandDto>> GetList();
}