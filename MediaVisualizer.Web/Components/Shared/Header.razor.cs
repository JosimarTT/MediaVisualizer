using MediaVisualizer.Web.Api;
using MediaVisualizer.Web.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace MediaVisualizer.Web.Components.Shared;

public partial class Header : IDisposable
{
    private ModalList _artistsModalRef;
    private ModalList _brandsModalRef;
    private ModalList _tagsModalRef;
    private List<string> artistItems = [];
    private List<string> brandItems = [];
    private bool isModalVisible = false;
    private string modalTitle;
    private List<string> tagItems = [];

    [Inject] private IBrandApi BrandApi { get; set; } = null!;
    [Inject] private IArtistApi ArtistApi { get; set; } = null!;
    [Inject] private ITagApi TagApi { get; set; } = null!;
    [Inject] private NavigationManager NavigationManager { get; set; } = null!;
    [Inject] private IFiltersStateService FiltersStateService { get; set; } = null!;

    public void Dispose()
    {
        NavigationManager.LocationChanged -= OnLocationChanged;
    }

    protected override void OnInitialized()
    {
        NavigationManager.LocationChanged += OnLocationChanged;
    }

    private void OnLocationChanged(object sender, LocationChangedEventArgs e)
    {
        StateHasChanged();
    }

    private async Task ShowModal(string title)
    {
        modalTitle = title;
        switch (title)
        {
            case "Tags":
                var tags = await TagApi.GetList();
                tagItems = tags.Select(x => x.Name).ToList();
                await _tagsModalRef.ShowModal();
                break;
            case "Artists":
                var artists = await ArtistApi.GetList();
                artistItems = artists.Select(x => x.Name).ToList();
                await _artistsModalRef.ShowModal();
                break;
            case "Brands":
                var brands = await BrandApi.GetList();
                brandItems = brands.Select(x => x.Name).ToList();
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
        var artists = await ArtistApi.GetList();
        var selectedArtists = artists
            .Where(x => selectedItems.Contains(x.Name))
            .Select(x => x.ArtistId)
            .ToList();
    }

    private async Task HandleBrandsSearchClicked(List<string> selectedItems)
    {
        var brands = await BrandApi.GetList();
        var selectedBrands = brands
            .Where(x => selectedItems.Contains(x.Name))
            .Select(x => x.BrandId)
            .ToList();

        // Do something with the selected brands
    }

    private async Task HandleTagsSearchClicked(List<string> selectedItems)
    {
        var tags = await TagApi.GetList();
        var selectedTags = tags
            .Where(x => selectedItems.Contains(x.Name))
            .Select(x => x.TagId)
            .ToList();

        // Do something with the selected tags
    }
}