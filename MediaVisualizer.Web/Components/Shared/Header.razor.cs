using MediaVisualizer.Shared.Requests;
using MediaVisualizer.Web.Api;
using MediaVisualizer.Web.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace MediaVisualizer.Web.Components.Shared;

public partial class Header : IDisposable
{
    private List<string> _artistItems = [];
    private ModalFilter _artistsModalRef = null!;
    private List<string> _brandItems = [];
    private ModalFilter _brandsModalRef = null!;
    private FiltersRequest _filters = new();
    private bool _isModalVisible = false;
    private string _modalTitle = string.Empty;
    private List<string> _tagItems = [];
    private ModalFilter _tagsModalRef = null!;


    private IEnumerable<string> AnimeTitles = new List<string> { "Naruto", "One Piece", "Attack on Titan" };
    private string selectedAutoCompleteText;
    private string selectedSearchValue;


    [Inject] private IBrandApi BrandApi { get; set; } = null!;
    [Inject] private IArtistApi ArtistApi { get; set; } = null!;
    [Inject] private ITagApi TagApi { get; set; } = null!;
    [Inject] private NavigationManager NavigationManager { get; set; } = null!;
    [Inject] private IFiltersStateService FiltersStateService { get; set; } = null!;

    public void Dispose()
    {
        NavigationManager.LocationChanged -= OnLocationChanged!;
    }

    private void HandleSearchChanged(string value)
    {
        Console.WriteLine($"Selected Value: {value}");
    }

    protected override void OnInitialized()
    {
        NavigationManager.LocationChanged += OnLocationChanged!;
    }

    private void OnLocationChanged(object sender, LocationChangedEventArgs e)
    {
        ClearAllFilters();
        StateHasChanged();
    }

    private async Task ShowModal(string title)
    {
        _modalTitle = title;
        switch (title)
        {
            case "Tags":
                var tags = await TagApi.GetListAsync();
                _tagItems = tags.Select(x => x.Name).ToList();
                await _tagsModalRef.ShowModal();
                break;
            case "Artists":
                var artists = await ArtistApi.GetListAsync();
                _artistItems = artists.Select(x => x.Name).ToList();
                await _artistsModalRef.ShowModal();
                break;
            case "Brands":
                var brands = await BrandApi.GetListAsync();
                _brandItems = brands.Select(x => x.Name).ToList();
                await _brandsModalRef.ShowModal();
                break;
        }
    }

    private bool IsCurrentPage(string pageName)
    {
        return NavigationManager.Uri.Contains(pageName, StringComparison.OrdinalIgnoreCase);
    }

    private async Task HandleArtistsSearchClicked(List<string> selectedItems)
    {
        var artists = await ArtistApi.GetListAsync();
        var selectedArtists = artists
            .Where(x => selectedItems.Contains(x.Name))
            .Select(x => x.ArtistId)
            .ToList();

        _filters.ArtistIds = selectedArtists;
        FiltersStateService.UpdateFilters(_filters);
    }

    private async Task HandleBrandsSearchClicked(List<string> selectedItems)
    {
        var brands = await BrandApi.GetListAsync();
        var selectedBrands = brands
            .Where(x => selectedItems.Contains(x.Name))
            .Select(x => x.BrandId)
            .ToList();

        _filters.BrandIds = selectedBrands;
        FiltersStateService.UpdateFilters(_filters);
    }

    private async Task HandleTagsSearchClicked(List<string> selectedItems)
    {
        var tags = await TagApi.GetListAsync();
        var selectedTags = tags
            .Where(x => selectedItems.Contains(x.Name))
            .Select(x => x.TagId)
            .ToList();

        _filters.TagIds = selectedTags;
        FiltersStateService.UpdateFilters(_filters);
    }

    private void ClearAllFilters()
    {
        FiltersStateService.ClearFilters();
        _artistsModalRef.ClearFilters();
        _brandsModalRef.ClearFilters();
        _tagsModalRef.ClearFilters();
    }
}