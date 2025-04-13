using System.Text.Json;
using MediaVisualizer.Shared.Dtos;
using MediaVisualizer.Shared.Requests;
using MediaVisualizer.Web.Api;
using MediaVisualizer.Web.Services;
using Microsoft.AspNetCore.Components;

namespace MediaVisualizer.Web.Components.Pages.Manwha;

public partial class ManwhaList : IDisposable
{
    private int _currentPage = 1;
    private bool _isLoading = true;
    private List<ManwhaDto> _manwhaList = [];
    private int _totalPages = 1;

    [Inject] private ILogger<ManwhaList> Logger { get; set; } = null!;
    [Inject] private IManwhaApi ManwhaApi { get; set; } = null!;
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
        await FetchManwhaList(FiltersStateService.Filters);
        StateHasChanged();
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        Logger.LogInformation("{MethodName} called with firstRender: {FirstRender}", nameof(OnAfterRenderAsync),
            firstRender);
        if (!firstRender) return;

        await FetchManwhaList(new FiltersRequest { Size = 18, Page = 1 });
        StateHasChanged();
    }

    private async Task FetchManwhaList(FiltersRequest filters)
    {
        Logger.LogInformation("{MethodName} called with filters: {Filters}", nameof(FetchManwhaList),
            JsonSerializer.Serialize(filters));
        _isLoading = true;
        var response = await ManwhaApi.GetListAsync(filters);
        _manwhaList = response.Items.ToList();
        _currentPage = filters.Page ?? 1;
        _totalPages = response.TotalPages;
        foreach (var manwha in _manwhaList)
            manwha.Logo = FileStreamApi.GetStreamImagePath(manwha.Logo, 210);

        _isLoading = false;
    }

    public async Task OnPageChanged(int newPage)
    {
        Logger.LogInformation("{MethodName} called with newPage: {NewPage}", nameof(OnPageChanged), newPage);
        FiltersStateService.Filters.Page = newPage;
        await FetchManwhaList(FiltersStateService.Filters);
    }
}