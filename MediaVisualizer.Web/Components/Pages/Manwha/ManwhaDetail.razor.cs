using Blazorise;
using MediaVisualizer.Shared.Dtos;
using MediaVisualizer.Web.Api;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace MediaVisualizer.Web.Components.Pages.Manwha;

public partial class ManwhaDetail
{
    private const int PageSize = 18;
    private readonly List<PageIsLoading> _pages = [];
    private int _currentPage = 1;
    private bool _isFirstRender = true;
    private bool _isLoading = true;
    private int _totalPages = 1;
    private int currentPage;
    private string modalImageUrl;

    private Modal modalRef;
    private ManwhaDto _manwha { get; set; }

    [Parameter] public int ManwhaId { get; set; }
    [Inject] private IManwhaApi ManwhaApi { get; set; }
    [Inject] private IFileStreamApi FileStreamApi { get; set; }


    protected override async Task OnInitializedAsync()
    {
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (!firstRender) return;

        _manwha = await ManwhaApi.GetAsync(ManwhaId);
        _totalPages = (int)Math.Ceiling((double)_manwha.Chapters.Count / PageSize);
        await LoadPages();
        _isLoading = false;
        await InvokeAsync(StateHasChanged);
    }

    private async Task LoadPages()
    {
        _pages.Clear();
        foreach (var chapter in _manwha.Chapters)
            for (var i = 1; i <= chapter.PagesCount; i++)
            {
                var filePath = Path.Combine(_manwha.BasePath, $"{chapter.ChapterNumber}-{i}.{chapter.PageExtension}");
                var logo = chapter.Logo;
                _pages.Add(new PageIsLoading
                {
                    pageNumber = i,
                    logo = FileStreamApi.GetStreamImagePath(chapter.Logo),
                    pagePath = FileStreamApi.GetStreamImagePath(filePath)
                });
            }
    }

    public async Task OnPageChanged(int newPage)
    {
        _currentPage = newPage;
    }

    private Task ShowModal(PageIsLoading manwhaPage)
    {
        modalImageUrl = manwhaPage.pageFullPath;
        currentPage = manwhaPage.pageNumber;
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
        if (currentPage >= _manwha.Chapters.Count) return;
        currentPage++;
        modalImageUrl = _pages.First(p => p.pageNumber == currentPage).pageFullPath;
    }

    private class PageIsLoading
    {
        public string logo { get; set; }
        public int pageNumber { get; set; }
        public string pagePath { get; set; }
        public string pageFullPath { get; set; }
        public bool IsLoading { get; set; } = true;
    }
}