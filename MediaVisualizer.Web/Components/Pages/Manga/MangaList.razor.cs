using System.Web;
using MediaVisualizer.Services.Dtos;
using MediaVisualizer.Shared.Requests;
using MediaVisualizer.Shared.Responses;
using MediaVisualizer.Web.Api;
using Microsoft.AspNetCore.Components;

namespace MediaVisualizer.Web.Components.Pages.Manga;

public partial class MangaList : IDisposable
{
    private int _currentPage = 1;
    private bool _isLoading = true;
    private List<MangaDto> _mangaList = new();
    private int _totalPages = 1;

    [Inject] private IMangaApi MangaApi { get; set; }
    [Inject] private IFileStreamApi FileStreamApi { get; set; }
    [Inject] private NavigationManager NavigationManager { get; set; }
    [Inject] private AppState AppState { get; set; }

    public void Dispose()
    {
        AppState.OnChange += OnMyChangeHandler;
    }

    protected override async Task OnInitializedAsync()
    {
        AppState.OnChange += OnMyChangeHandler;
        AppState.EnableButtons(true, false, true);
        await FetchMangaList(new FiltersRequest { Size = 18, Page = 1 });
    }

    private async Task FetchMangaList(FiltersRequest filters)
    {
        _isLoading = true;
        _currentPage = filters.Page ?? 1;

        await FetchCurrentPage(filters);

        _isLoading = false;
        // UpdateUrlWithCurrentPage();
    }

    private async Task FetchCurrentPage(FiltersRequest filters)
    {
        var currentPageResponse = await FetchPage(filters);
        _totalPages = currentPageResponse.TotalPages;
        _mangaList = currentPageResponse.Items.ToList();
        foreach (var manga in _mangaList)
            manga.Logo = FileStreamApi.GetStreamImagePath([manga.Logo], 20);
    }

    private async Task<ListResponse<MangaDto>> FetchPage(FiltersRequest filters)
    {
        var response = await MangaApi.GetList(filters);
        response.Page = filters.Page ?? 1;
        return response;
    }

    public async Task OnPageChanged(int newPage)
    {
        await FetchMangaList(new FiltersRequest { Size = 18, Page = newPage });
    }

    private void UpdateUrlWithCurrentPage()
    {
        var uri = new Uri(NavigationManager.Uri);
        var query = HttpUtility.ParseQueryString(uri.Query);
        query["page"] = _currentPage.ToString();
        var newUri = $"{uri.GetLeftPart(UriPartial.Path)}?{query}";
        NavigationManager.NavigateTo(newUri, false);
    }

    private async void OnMyChangeHandler()
    {
        await InvokeAsync(StateHasChanged);
    }
}