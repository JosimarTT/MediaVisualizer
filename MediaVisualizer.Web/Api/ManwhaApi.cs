using MediaVisualizer.Shared.Dtos;

namespace MediaVisualizer.Web.Api;

public class ManwhaApi : IManwhaApi
{
    private readonly HttpClient _httpClient;

    public ManwhaApi(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public Task<ManwhaDto> Get(int manwhaId)
    {
        return _httpClient.GetFromJsonAsync<ManwhaDto>($"Manwha/{manwhaId}");
    }

    public Task<ManwhaDto> GetRandom()
    {
        return _httpClient.GetFromJsonAsync<ManwhaDto>("Manwha/GetRandom");
    }
}

public interface IManwhaApi
{
    Task<ManwhaDto> Get(int manwhaId);
    Task<ManwhaDto> GetRandom();
}