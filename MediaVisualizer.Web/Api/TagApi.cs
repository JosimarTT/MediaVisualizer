using MediaVisualizer.Services.Dtos;
using MediaVisualizer.Web.Helpers;

namespace MediaVisualizer.Web.Api;

public class TagApi : ITagApi
{
    private readonly HttpClient _httpClient;
    private readonly PersistentDataHelper _persistentDataHelper;

    public TagApi(HttpClient httpClient, PersistentDataHelper persistentDataHelper)
    {
        _httpClient = httpClient;
        _persistentDataHelper = persistentDataHelper;
    }

    public Task<List<TagDto>> GetList()
    {
        return _persistentDataHelper.Tags.Count > 0
            ? Task.FromResult(_persistentDataHelper.Tags.ToList())
            : _httpClient.GetFromJsonAsync<List<TagDto>>("Tag/GetList");
    }
}

public interface ITagApi
{
    Task<List<TagDto>> GetList();
}