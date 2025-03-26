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
        _manga = await HttpClient.GetFromJsonAsync<MangaDto>($"Manga/{MangaId}")!;
        await LoadPages(1, 18);
        _isLoading = false;
    }

    private async Task LoadPages(int startPage, int pageCount)
    {
        for (var i = startPage; i < startPage + pageCount && i <= _manga.PagesCount; i++)
        {
            var filePath = Path.Combine(StringConstants.MangaCollectionPath, _manga.Folder,
                $"{i:D3}{_manga.PageExtension}");
            var encodedFilePath = Uri.EscapeDataString(filePath);
            var pageUrl =
                $"{HttpClient.BaseAddress}FileStream/StreamImage?filePath={encodedFilePath}&percentage=20&quality=50";
            _pages.Add(pageUrl);
        }
    }
}