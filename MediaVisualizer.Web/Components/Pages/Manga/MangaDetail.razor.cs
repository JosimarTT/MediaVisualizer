using MediaVisualizer.Services.Dtos;
using MediaVisualizer.Shared;
using Microsoft.AspNetCore.Components;

namespace MediaVisualizer.Web.Components.Pages.Manga;

public partial class MangaDetail
{
    private const int PageSize = 18;
    private readonly List<PageIsLoading> _pages = new();
    private int _currentPage = 1;
    private bool _isFirstRender = true;
    private bool _isLoading = true;
    private int _totalPages = 1;
    private MangaDto _manga { get; set; }

    [Parameter] public int MangaId { get; set; }
    [Inject] private HttpClient HttpClient { get; set; }

    protected override async Task OnInitializedAsync()
    {
        _manga = await HttpClient.GetFromJsonAsync<MangaDto>($"Manga/{MangaId}")!;
        _totalPages = (int)Math.Ceiling((double)_manga.PagesCount / PageSize);
        await LoadPages(_currentPage);
        _isLoading = false;
    }

    private async Task LoadPages(int page)
    {
        _pages.Clear();
        var startPage = (page - 1) * PageSize + 1;
        for (var i = startPage; i < startPage + PageSize && i <= _manga.PagesCount; i++)
        {
            var filePath = Path.Combine(StringConstants.MangaCollectionPath, _manga.Folder,
                $"{i:D3}{_manga.PageExtension}");
            var encodedFilePath = Uri.EscapeDataString(filePath);
            var pageUrl =
                $"{HttpClient.BaseAddress}FileStream/StreamImage?filePath={encodedFilePath}&percentage=20";
            _pages.Add(new PageIsLoading { pagePath = pageUrl });
        }
    }

    public async Task OnPageChanged(int newPage)
    {
        _currentPage = newPage;
        await LoadPages(newPage);
    }

    private class PageIsLoading
    {
        public string pagePath { get; set; }
        public bool IsLoading { get; set; } = true;
    }
}