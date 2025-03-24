using Microsoft.JSInterop;

namespace MediaVisualizer.Web.Components.Pages.Anime;

public partial class AnimeDetail
{
    private bool _isFirstRender = true;

    protected override async Task OnInitializedAsync()
    {
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender && _isFirstRender)
        {
            _isFirstRender = false;
            await SetVideoSource();
        }
    }

    private async Task SetVideoSource()
    {
        var videoUrl = "http://localhost:5118/Anime/Stream";
        await JSRuntime.InvokeVoidAsync("setVideoSource", "animeVideo", videoUrl);
    }
}