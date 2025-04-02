using MediaVisualizer.Services.Dtos;
using MediaVisualizer.Shared.Requests;
using MediaVisualizer.Web.Api;
using MediaVisualizer.Web.Helpers;
using Microsoft.AspNetCore.Components;

namespace MediaVisualizer.Web.Components.Pages.Anime;

public partial class AnimeList
{
    private List<AnimeDto> _animeList = [];
    private List<BrandDto> _brands = [];
    private List<TagDto> _tags = [];
    private int _currentPage = 1;
    private bool _isLoading = true;
    private int _totalPages = 1;

    [Inject] private IAnimeApi AnimeApi { get; set; } = null!;
    [Inject] private IFileStreamApi FileStreamApi { get; set; } = null!;
    [Inject] private IBrandApi BrandApi { get; set; } = null!;
    [Inject] private ITagApi TagApi { get; set; } = null!;
    [Inject] private PersistentDataHelper PersistentDataHelper { get; set; } = null!;

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
        var brandsTask = BrandApi.GetList();
        var tagsTask = TagApi.GetList();
        await Task.WhenAll(brandsTask, tagsTask);
        _brands = await brandsTask;
        _tags = await tagsTask;
        StateHasChanged();
    }

    public async Task OnPageChanged(int newPage)
    {
        _currentPage = newPage;
        await FetchAnimeList(new FiltersRequest { Size = 18, Page = newPage });
    }
}