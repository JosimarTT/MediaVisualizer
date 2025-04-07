using System.Web;
using MediaVisualizer.Services.Dtos;
using MediaVisualizer.Shared.Requests;
using MediaVisualizer.Shared.Responses;
using MediaVisualizer.Web.Api;
using Microsoft.AspNetCore.Components;

namespace MediaVisualizer.Web.Components.Pages.Manga;

public partial class MangaList
{
    private int _currentPage = 1;
    private bool _isLoading = true;
    private List<MangaDto> _mangaList = [];
    private int _totalPages = 1;

    [Inject] private IMangaApi MangaApi { get; set; }
    [Inject] private IFileStreamApi FileStreamApi { get; set; }
    [Inject] private NavigationManager NavigationManager { get; set; }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (!firstRender) return;

        await FetchMangaList(new FiltersRequest { Size = 18, Page = 1 });
        await InvokeAsync(StateHasChanged);
    }

    private async Task FetchMangaList(FiltersRequest filters)
    {
        _isLoading = true;
        _currentPage = filters.Page ?? 1;

        await FetchCurrentPage(filters);

        _isLoading = false;
    }

    private async Task FetchCurrentPage(FiltersRequest filters)
    {
        var currentPageResponse = await FetchPage(filters);
        _totalPages = currentPageResponse.TotalPages;
        _mangaList = currentPageResponse.Items.ToList();
        foreach (var manga in _mangaList)
            manga.Logo = FileStreamApi.GetStreamImagePath(manga.Logo, 210);
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
}