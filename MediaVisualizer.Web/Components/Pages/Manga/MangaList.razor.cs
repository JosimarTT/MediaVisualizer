using System.Web;
using MediaVisualizer.Services.Dtos;
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

    protected override async Task OnInitializedAsync()
    {
        await FetchMangaList(new FiltersRequest { Size = 18, Page = 1 });
    }

    private async Task FetchMangaList(FiltersRequest filters)
    {
        _isLoading = true;

        var query = HttpUtility.ParseQueryString(string.Empty);
        if (filters.Size.HasValue) query["Size"] = filters.Size.Value.ToString();
        if (filters.Page.HasValue) query["Page"] = filters.Page.Value.ToString();
        if (!string.IsNullOrEmpty(filters.SortOrder)) query["SortOrder"] = filters.SortOrder;
        if (filters.AuthorIds != null) query["AuthorIds"] = string.Join(",", filters.AuthorIds);
        if (filters.TagIds != null) query["TagIds"] = string.Join(",", filters.TagIds);
        if (filters.BrandIds != null) query["BrandIds"] = string.Join(",", filters.BrandIds);
        if (filters.ArtistIds != null) query["ArtistIds"] = string.Join(",", filters.ArtistIds);
        if (!string.IsNullOrEmpty(filters.Title)) query["Title"] = filters.Title;

        var url = $"Manga/GetList?{query}";
        var response = await HttpClient.GetFromJsonAsync<ListResponse<MangaDto>>(url);
        if (response != null)
        {
            _mangaList = response.Items.ToList();
            _totalPages = response.TotalPages;
        }

        _currentPage = filters.Page ?? 1;
        _isLoading = false;
    }

    public async Task OnPageChanged(int newPage)
    {
        _currentPage = newPage;
        await FetchMangaList(new FiltersRequest { Size = 18, Page = newPage });
    }
}