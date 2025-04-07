using MediaVisualizer.Services.Dtos;
using MediaVisualizer.Web.Api;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace MediaVisualizer.Web.Components.Pages.Anime;

public partial class AnimeDetail
{
    private bool _isFirstRender = true;
    private AnimeDto Anime { get; set; }

    [Parameter] public int AnimeId { get; set; }

    [Inject] private IAnimeApi AnimeApi { get; set; } = null!;
    [Inject] private IFileStreamApi FileStreamApi { get; set; } = null!;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender && _isFirstRender)
        {
            _isFirstRender = false;
            Anime = await AnimeApi.Get(AnimeId);
            await SetVideoSource(FileStreamApi.GetStreamVideoPath(Anime.Video));
        }
    }

    private async Task SetVideoSource(string url)
    {
        ;
        await JSRuntime.InvokeVoidAsync("setVideoSource", "animeVideo", url);
    }
}