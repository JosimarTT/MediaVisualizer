using System.Web;
using MediaVisualizer.Services.Dtos;
using MediaVisualizer.Shared.Requests;
using MediaVisualizer.Shared.Responses;
using MediaVisualizer.Web.Api;
using Microsoft.AspNetCore.Components;

namespace MediaVisualizer.Web.Components.Pages.Anime;

public partial class AnimeList
{
    private List<AnimeDto> _animeList = new();
    private int _currentPage = 1;
    private bool _isFirstRender = true;
    private bool _isLoading = true;
    private int _totalPages = 1;

    [Inject] private HttpClient HttpClient { get; set; }
    [Inject] private IFileStreamApi FileStreamApi { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Console.WriteLine("AnimeList OnInitializedAsync called");
        await FetchAnimeList(new FiltersRequest { Size = 18, Page = 1 });
    }

    private async Task FetchAnimeList(FiltersRequest filters)
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

        var url = $"Anime/GetList?{query}";
        var response = await HttpClient.GetFromJsonAsync<ListResponse<AnimeDto>>(url);
        if (response != null)
        {
            _animeList = response.Items.ToList();
            foreach (var anime in _animeList)
                anime.Logo = FileStreamApi.GetStreamImagePath([anime.Logo]);
            _totalPages = response.TotalPages;
        }

        _currentPage = filters.Page ?? 1;
        _isLoading = false;
    }

    public async Task OnPageChanged(int newPage)
    {
        _currentPage = newPage;
        await FetchAnimeList(new FiltersRequest { Size = 18, Page = newPage });
    }
}