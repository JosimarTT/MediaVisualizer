using MediaVisualizer.Services.Dtos;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace MediaVisualizer.Web.Components.Pages.Anime;

public partial class AnimeDetail
{
    private bool _isFirstRender = true;
    [Parameter] public int AnimeId { get; set; }
    private AnimeDto Anime { get; set; }
    [Inject] private HttpClient HttpClient { get; set; }

    protected override async Task OnInitializedAsync()
    {
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender && _isFirstRender)
        {
            _isFirstRender = false;
            Anime = await HttpClient.GetFromJsonAsync<AnimeDto>($"Anime/{AnimeId}");
            await SetVideoSource($"{Anime.Folder}/{Anime.Video}");
        }
    }

    private async Task SetVideoSource(string path)
    {
        var videoUrl = $"http://localhost:5118/Anime/Stream?path={path}";
        await JSRuntime.InvokeVoidAsync("setVideoSource", "animeVideo", videoUrl);
    }
}