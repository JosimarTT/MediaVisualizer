using MediaVisualizer.Services.Dtos;
using MediaVisualizer.Shared;
using Microsoft.AspNetCore.Components;

namespace MediaVisualizer.Web.Components.Pages.Manga;

public partial class MangaDetail
{
    private readonly List<string> _pages = new();
    private bool _isFirstRender = true;
    private bool _isLoading = true;
    private MangaDto _manga { get; set; }
    [Parameter] public int MangaId { get; set; }
    [Inject] private HttpClient HttpClient { get; set; }

    protected override async Task OnInitializedAsync()
    {
        _manga = await HttpClient.GetFromJsonAsync<MangaDto>($"Manga/{MangaId}");
        await LoadPages();
        _isLoading = false;
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender && _isFirstRender)
        {
            _isFirstRender = false;
        }
    }

    private async Task LoadPages()
    {
        _isLoading = true;
        for (var i = 1; i <= _manga.PagesCount; i++)
        {
            var filePath = Path.Combine(StringConstants.MangaCollectionPath, _manga.Folder,
                $"{i:D3}{_manga.PageExtension}");
            var encodedFilePath = Uri.EscapeDataString(filePath);
            var pageUrl =
                await HttpClient.GetStringAsync($"FileProcessor/ProcessImage?filePath={encodedFilePath}&percentage=20");
            _pages.Add(pageUrl);
        }

        _isLoading = false;
    }
}