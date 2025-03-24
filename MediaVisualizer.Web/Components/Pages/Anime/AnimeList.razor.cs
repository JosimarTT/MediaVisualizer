using System.Web;
using MediaVisualizer.Services.Dtos;
using MediaVisualizer.Shared.Requests;
using MediaVisualizer.Shared.Responses;
using Microsoft.AspNetCore.Components;

namespace MediaVisualizer.Web.Components.Pages.Anime;

public partial class AnimeList
{
    private List<AnimeDto> _animeList = new();
    private bool _isLoading = true;
    [Inject] private HttpClient HttpClient { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await FetchAnimeList();
    }

    private async Task FetchAnimeList()
    {
        var filters = new FiltersRequest
        {
            Size = 18,
            Page = 1
        };

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
        if (response != null) _animeList = response.Items.ToList();
        _isLoading = false;
    }
}