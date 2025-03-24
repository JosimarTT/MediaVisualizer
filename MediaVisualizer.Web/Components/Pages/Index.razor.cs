namespace MediaVisualizer.Web.Components.Pages;

public partial class Index
{
    private string? _animeImageUrl;
    private bool _isLoading = true;
    private string? _mangaImageUrl;
    private string? _manwhaImageUrl;

    protected override async Task OnInitializedAsync()
    {
        var animeTask = FetchImageUrl("Anime/GetRandom");
        var mangaTask = FetchImageUrl("Manga/GetRandom");
        var manwhaTask = FetchImageUrl("Manwha/GetRandom");

        var results = await Task.WhenAll(animeTask, mangaTask, manwhaTask);

        _animeImageUrl = results[0];
        _mangaImageUrl = results[1];
        _manwhaImageUrl = results[2];
        _isLoading = false;
    }

    private async Task<string> FetchImageUrl(string endpoint)
    {
        var response = await HttpClient.GetAsync(endpoint);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }
}