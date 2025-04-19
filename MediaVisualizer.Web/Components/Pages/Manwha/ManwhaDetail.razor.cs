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
    private readonly List<string> modalImageUrl = [];
    private int _currentPage = 1;
    private bool _isFirstRender = true;
    private bool _isLoading = true;
    private int _totalPages = 1;
    private int currentChapter;


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
        for (var i = 1; i <= _manwha.Chapters.Count; i++)
            _pages.Add(new PageIsLoading
            {
                pageNumber = i,
                logo = FileStreamApi.GetStreamImagePath(_manwha.Chapters.ToList()[i - 1].Logo)
            });
    }

    public async Task OnPageChanged(int newPage)
    {
        _currentPage = newPage;
    }

    private Task ShowModal(PageIsLoading manwhaPage)
    {
        modalImageUrl.Clear();
        var chapter = _manwha.Chapters.ToList()[manwhaPage.pageNumber - 1];
        for (var i = 1; i <= chapter.PagesCount; i++)
        {
            var path = Path.Combine(_manwha.BasePath, $"{chapter.ChapterNumber}-{i}{chapter.PageExtension}");
            modalImageUrl.Add(FileStreamApi.GetStreamImagePath(path));
        }

        currentChapter = manwhaPage.pageNumber;
        return modalRef.Show();
    }

    private async Task OnKeyDown(KeyboardEventArgs e)
    {
        switch (e.Key)
        {
            case "ArrowLeft":
                ShowPreviousChapter();
                break;
            case "ArrowRight":
                ShowNextChapter();
                break;
        }
    }

    private void ShowChapter(int chapterNumber)
    {
        modalImageUrl.Clear();
        var chapter = _manwha.Chapters.ToList()[chapterNumber - 1];
        for (var i = 1; i <= chapter.PagesCount; i++)
        {
            var path = Path.Combine(_manwha.BasePath, $"{chapter.ChapterNumber}-{i}{chapter.PageExtension}");
            modalImageUrl.Add(FileStreamApi.GetStreamImagePath(path));
        }

        currentChapter = chapterNumber;
    }

    private void ShowPreviousChapter()
    {
        if (currentChapter > 1) ShowChapter(--currentChapter);
    }

    private void ShowNextChapter()
    {
        if (currentChapter < _manwha.Chapters.Count) ShowChapter(++currentChapter);
    }

    private class PageIsLoading
    {
        public string logo { get; set; }
        public int pageNumber { get; set; }
    }
}