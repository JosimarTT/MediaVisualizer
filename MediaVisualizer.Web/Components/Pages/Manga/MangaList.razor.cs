using System.Web;
using MediaVisualizer.Services.Dtos;
using MediaVisualizer.Shared;
using MediaVisualizer.Shared.Requests;
using MediaVisualizer.Shared.Responses;
using Microsoft.AspNetCore.Components;

namespace MediaVisualizer.Web.Components.Pages.Manga;

public partial class MangaList
{
    private int _currentPage = 1;
    private bool _isLoading = true;
    private List<MangaDto> _mangaList = new();
    private int _totalPages = 1;
    [Inject] private HttpClient HttpClient { get; set; }
    [Inject] private NavigationManager NavigationManager { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await FetchMangaList(new FiltersRequest { Size = 18, Page = 1 });
    }

    private async Task FetchMangaList(FiltersRequest filters)
    {
        _isLoading = true;
        _currentPage = filters.Page ?? 1;

        await FetchCurrentPage(filters);

        _isLoading = false;
        UpdateUrlWithCurrentPage();
    }

    private async Task FetchCurrentPage(FiltersRequest filters)
    {
        var currentPageResponse = await FetchPage(filters);
        _totalPages = currentPageResponse.TotalPages;
        _mangaList = currentPageResponse.Items.ToList();
        foreach (var manga in _mangaList)
        {
            var filePath = Path.Combine(StringConstants.MangaCollectionPath, manga.Folder,
                $"001{manga.PageExtension}");
            var encodedFilePath = Uri.EscapeDataString(filePath);
            var pageUrl =
                $"{HttpClient.BaseAddress}FileStream/StreamImage?filePath={encodedFilePath}&percentage=20&quality=50";
            manga.Logo = pageUrl;
        }
    }

    private async Task<ListResponse<MangaDto>> FetchPage(FiltersRequest filters)
    {
        var query = HttpUtility.ParseQueryString(string.Empty);
        if (filters.Size.HasValue) query["Size"] = filters.Size.Value.ToString();
        if (filters.Page.HasValue) query["Page"] = filters.Page.Value.ToString();
        if (!string.IsNullOrEmpty(filters.SortOrder)) query["SortOrder"] = filters.SortOrder;
        if (filters.AuthorIds != null) query["AuthorIds"] = string.Join(",", filters.AuthorIds);
        if (filters.TagIds != null) query["TagIds"] = string.Join(",", filters.TagIds);
        if (filters.BrandIds != null) query["BrandIds"] = string.Join(",", filters.BrandIds);
        if (filters.ArtistIds != null) query["ArtistIds"] = string.Join(",", filters.ArtistIds);
        if (!string.IsNullOrEmpty(filters.Title)) query["Title"] = filters.Title;
        query["Percentage"] = 20.ToString();
        var url = $"Manga/GetList?{query}";
        var response = await HttpClient.GetFromJsonAsync<ListResponse<MangaDto>>(url);
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