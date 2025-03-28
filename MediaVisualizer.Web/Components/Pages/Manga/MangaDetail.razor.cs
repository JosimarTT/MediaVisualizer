using Blazorise;
using MediaVisualizer.Services.Dtos;
using MediaVisualizer.Web.Api;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace MediaVisualizer.Web.Components.Pages.Manga;

public partial class MangaDetail
{
    private const int PageSize = 18;
    private readonly List<PageIsLoading> _pages = new();
    private int _currentPage = 1;
    private bool _isFirstRender = true;
    private bool _isLoading = true;
    private int _totalPages = 1;
    private int currentPage;
    private string modalImageUrl;

    private Modal modalRef;
    private MangaDto _manga { get; set; }

    [Parameter] public int MangaId { get; set; }
    [Inject] private IMangaApi MangaApi { get; set; }
    [Inject] private IFileStreamApi FileStreamApi { get; set; }

    protected override async Task OnInitializedAsync()
    {
        _manga = await MangaApi.Get(MangaId);
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
            var filePath = Path.Combine(_manga.BasePath, $"{i:D3}{_manga.PageExtension}");

            _pages.Add(new PageIsLoading
            {
                pageNumber = i,
                pagePath = FileStreamApi.GetStreamImagePath([filePath], 20),
                pageFullPath = FileStreamApi.GetStreamImagePath([filePath])
            });
        }
    }

    public async Task OnPageChanged(int newPage)
    {
        _currentPage = newPage;
        await LoadPages(newPage);
    }

    private Task ShowModal(PageIsLoading mangaPage)
    {
        modalImageUrl = mangaPage.pageFullPath;
        currentPage = mangaPage.pageNumber;
        return modalRef.Show();
    }

    private void OnKeyDown(KeyboardEventArgs e)
    {
        switch (e.Key)
        {
            case "ArrowLeft":
                ShowPreviousImage();
                break;
            case "ArrowRight":
                ShowNextImage();
                break;
        }
    }

    private void ShowPreviousImage()
    {
        if (currentPage <= 1) return;
        currentPage--;
        modalImageUrl = _pages.First(p => p.pageNumber == currentPage).pageFullPath;
    }

    private void ShowNextImage()
    {
        if (currentPage >= _pages.Count) return;
        currentPage++;
        modalImageUrl = _pages.First(p => p.pageNumber == currentPage).pageFullPath;
    }

    private class PageIsLoading
    {
        public int pageNumber { get; set; }
        public string pagePath { get; set; }
        public string pageFullPath { get; set; }
        public bool IsLoading { get; set; } = true;
    }
}