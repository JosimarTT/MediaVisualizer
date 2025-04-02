using MediaVisualizer.Services.Dtos;

namespace MediaVisualizer.Web.Api;

public class TagApi : ITagApi
{
    private readonly HttpClient _httpClient;

    public TagApi(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public Task<List<TagDto>> GetList()
    {
        return _httpClient.GetFromJsonAsync<List<TagDto>>("Tag/GetList");
    }
}

public interface ITagApi
{
    Task<List<TagDto>> GetList();
}