using MediaVisualizer.Services.Dtos;

namespace MediaVisualizer.Web.Api;

public class TagApi : ITagApi
{
    private const string BaseUrl = "Tag";
    private readonly HttpClient _httpClient;

    public TagApi(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public Task<List<TagDto>> GetListAsync()
    {
        return _httpClient.GetFromJsonAsync<List<TagDto>>($"{BaseUrl}/GetList");
    }
}

public interface ITagApi
{
    Task<List<TagDto>> GetListAsync();
}