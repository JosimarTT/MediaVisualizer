using MediaVisualizer.Services.Dtos;
using MediaVisualizer.Shared.Requests;
using MediaVisualizer.Web.Api;
using MediaVisualizer.Web.Helpers;
using Microsoft.AspNetCore.Components;

namespace MediaVisualizer.Web.Components.Pages.Anime;

public partial class AnimeList
{
    private List<AnimeDto> _animeList = new();
    private List<BrandDto> _brands = [];
    private int _currentPage = 1;
    private bool _isLoading = true;
    private List<TagDto> _tags = [];
    private int _totalPages = 1;

    [Inject] private IAnimeApi AnimeApi { get; set; }
    [Inject] private IFileStreamApi FileStreamApi { get; set; }
    [Inject] private IBrandApi BrandApi { get; set; }
    [Inject] private ITagApi TagApi { get; set; }
    [Inject] private PersistentDataHelper PersistentDataHelper { get; set; }

    private async Task FetchAnimeList(FiltersRequest filters)
    {
        _isLoading = true;
        var response = await AnimeApi.GetList(filters);
        _animeList = response.Items.ToList();
        foreach (var anime in _animeList)
            anime.Logo = FileStreamApi.GetStreamImagePath([anime.Logo]);
        _totalPages = response.TotalPages;
        _currentPage = filters.Page ?? 1;
        _isLoading = false;
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (!firstRender) return;

        await FetchAnimeList(new FiltersRequest { Size = 18, Page = 1 });
        _brands = await BrandApi.GetList();
        _tags = await TagApi.GetList();
        await InvokeAsync(StateHasChanged);
    }

    public async Task OnPageChanged(int newPage)
    {
        _currentPage = newPage;
        await FetchAnimeList(new FiltersRequest { Size = 18, Page = newPage });
    }
}