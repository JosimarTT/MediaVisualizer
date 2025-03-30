using MediaVisualizer.Services.Dtos;
using MediaVisualizer.Web.Api;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace MediaVisualizer.Web.Components.Pages.Anime;

public partial class AnimeDetail : IDisposable
{
    private bool _isFirstRender = true;
    [Parameter] public int AnimeId { get; set; }
    private AnimeDto Anime { get; set; }

    [Inject] private IAnimeApi AnimeApi { get; set; }
    [Inject] private IFileStreamApi FileStreamApi { get; set; }
    [Inject] private AppState AppState { get; set; }

    public void Dispose()
    {
        AppState.OnChange -= OnMyChangeHandler;
    }

    protected override async Task OnInitializedAsync()
    {
        AppState.OnChange += OnMyChangeHandler;
        AppState.EnableButtons(false, true, true);
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender && _isFirstRender)
        {
            _isFirstRender = false;
            Anime = await AnimeApi.Get(AnimeId);
            await SetVideoSource(FileStreamApi.GetStreamVideoPath([Anime.Video]));
        }
    }

    private async Task SetVideoSource(string url)
    {
        ;
        await JSRuntime.InvokeVoidAsync("setVideoSource", "animeVideo", url);
    }

    private async void OnMyChangeHandler()
    {
        await InvokeAsync(StateHasChanged);
    }
}