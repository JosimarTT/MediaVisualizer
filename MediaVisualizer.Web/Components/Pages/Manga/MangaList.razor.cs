using System.Text.Json;
using MediaVisualizer.Services.Dtos;
using MediaVisualizer.Shared.Requests;
using MediaVisualizer.Web.Api;
using MediaVisualizer.Web.Services;
using Microsoft.AspNetCore.Components;

namespace MediaVisualizer.Web.Components.Pages.Manga;

public partial class MangaList : IDisposable
{
    private int _currentPage = 1;
    private bool _isLoading = true;
    private List<MangaDto> _mangaList = [];
    private int _totalPages = 1;

    [Inject] private ILogger<MangaList> Logger { get; set; } = null!;
    [Inject] private IMangaApi MangaApi { get; set; } = null!;
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
        await FetchMangaList(FiltersStateService.Filters);
        StateHasChanged();
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        Logger.LogInformation("{MethodName} called with firstRender: {FirstRender}", nameof(OnAfterRenderAsync),
            firstRender);
        if (!firstRender) return;

        await FetchMangaList(new FiltersRequest { Size = 18, Page = 1 });
        StateHasChanged();
    }

    private async Task FetchMangaList(FiltersRequest filters)
    {
        Logger.LogInformation("{MethodName} called with filters: {Filters}", nameof(FetchMangaList),
            JsonSerializer.Serialize(filters));
        _isLoading = true;
        var response = await MangaApi.GetListAsync(filters);
        _mangaList = response.Items.ToList();
        _currentPage = filters.Page ?? 1;
        _totalPages = response.TotalPages;
        foreach (var manga in _mangaList)
            manga.Logo = FileStreamApi.GetStreamImagePath(manga.Logo, 210);

        _isLoading = false;
    }

    public async Task OnPageChanged(int newPage)
    {
        Logger.LogInformation("{MethodName} called with newPage: {NewPage}", nameof(OnPageChanged), newPage);
        FiltersStateService.Filters.Page = newPage;
        await FetchMangaList(FiltersStateService.Filters);
    }
}