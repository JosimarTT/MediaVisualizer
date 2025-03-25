using System.Web;
using MediaVisualizer.Services.Dtos;
using MediaVisualizer.Shared.Requests;
using MediaVisualizer.Shared.Responses;
using Microsoft.AspNetCore.Components;

namespace MediaVisualizer.Web.Components.Pages.Manga;

public partial class MangaList
{
    private readonly Dictionary<int, List<MangaDto>> _pageCache = new();
    private int _currentPage = 1;
    private bool _isLoading = true;
    private List<MangaDto> _mangaList = new();
    private int _totalPages = 1;
    [Inject] private HttpClient HttpClient { get; set; }

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

        _ = FetchRemainingPages(filters);
    }

    private async Task FetchCurrentPage(FiltersRequest filters)
    {
        if (!_pageCache.TryGetValue(_currentPage, out var cachedPage))
        {
            var currentPageResponse = await FetchPage(filters);
            _pageCache[_currentPage] = currentPageResponse.Items.ToList();
            _totalPages = currentPageResponse.TotalPages;
            _mangaList = currentPageResponse.Items.ToList();
        }
        else
        {
            _mangaList = cachedPage;
        }
    }

    private async Task FetchRemainingPages(FiltersRequest filters)
    {
        var pagesToCheck = new List<int> { _currentPage };
        if (_currentPage > 1) pagesToCheck.Add(_currentPage - 1);
        if (_currentPage > 2) pagesToCheck.Add(_currentPage - 2);
        if (_currentPage < _totalPages) pagesToCheck.Add(_currentPage + 1);
        if (_currentPage < _totalPages - 1) pagesToCheck.Add(_currentPage + 2);

        var pagesToFetch = pagesToCheck
            .Where(page => !_pageCache.ContainsKey(page))
            .Distinct()
            .ToList();

        var tasks = pagesToFetch
            .Select(page => FetchPage(new FiltersRequest { Size = filters.Size, Page = page }))
            .ToList();

        var responses = await Task.WhenAll(tasks);

        foreach (var response in responses)
            if (response != null)
                _pageCache[response.Page] = response.Items.ToList();

        var pagesToKeep = new HashSet<int>
            { _currentPage, _currentPage - 1, _currentPage - 2, _currentPage + 1, _currentPage + 2 };

        foreach (var page in _pageCache.Keys.ToList())
            if (!pagesToKeep.Contains(page))
                _pageCache.Remove(page);
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
}