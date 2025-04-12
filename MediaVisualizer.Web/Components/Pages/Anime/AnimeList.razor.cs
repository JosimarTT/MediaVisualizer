using System.Text.Json;
using MediaVisualizer.Services.Dtos;
using MediaVisualizer.Shared.Requests;
using MediaVisualizer.Web.Api;
using MediaVisualizer.Web.Services;
using Microsoft.AspNetCore.Components;

namespace MediaVisualizer.Web.Components.Pages.Anime;

public partial class AnimeList : IDisposable
{
    private List<AnimeDto> _animeList = [];
    private int _currentPage = 1;
    private bool _isLoading = true;
    private int _totalPages = 1;

    [Inject] private ILogger<AnimeList> Logger { get; set; } = null!;
    [Inject] private IAnimeApi AnimeApi { get; set; } = null!;
    [Inject] private IFileStreamApi FileStreamApi { get; set; } = null!;
    [Inject] private IFiltersStateService FiltersStateService { get; set; } = null!;

    public void Dispose()
    {
        Logger.LogInformation("{MethodName} called", nameof(Dispose));
        FiltersStateService.OnFiltersChanged -= HandleFiltersChanged;
    }

    protected override void OnInitialized()
    {
        Logger.LogInformation("{MethodName} called", nameof(OnInitialized));
        FiltersStateService.OnFiltersChanged += HandleFiltersChanged;
    }

    private async void HandleFiltersChanged()
    {
        Logger.LogInformation("{MethodName} called", nameof(HandleFiltersChanged));
        await FetchAnimeList(FiltersStateService.Filters);
        StateHasChanged();
    }

    private async Task FetchAnimeList(FiltersRequest filters)
    {
        Logger.LogInformation("{MethodName} called with filters: {Filters}", nameof(FetchAnimeList),
            JsonSerializer.Serialize(filters));
        _isLoading = true;
        var response = await AnimeApi.GetListAsync(filters);
        _animeList = response.Items.ToList();
        foreach (var anime in _animeList)
            anime.Logo = FileStreamApi.GetStreamImagePath(anime.Logo);
        _totalPages = response.TotalPages;
        _currentPage = filters.Page ?? 1;
        _isLoading = false;
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        Logger.LogInformation("{MethodName} called with firstRender: {FirstRender}", nameof(OnAfterRenderAsync),
            firstRender);
        if (!firstRender) return;

        await FetchAnimeList(new FiltersRequest { Size = 18, Page = 1 });
        StateHasChanged();
    }

    public async Task OnPageChanged(int newPage)
    {
        Logger.LogInformation("{MethodName} called with newPage: {NewPage}", nameof(OnPageChanged), newPage);
        _currentPage = newPage;
        FiltersStateService.Filters.Page = newPage;
        await FetchAnimeList(FiltersStateService.Filters);
    }
}