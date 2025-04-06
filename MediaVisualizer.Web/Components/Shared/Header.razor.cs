using MediaVisualizer.Web.Api;
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

    [Inject] private IBrandApi BrandApi { get; set; }
    [Inject] private IArtistApi ArtistApi { get; set; }
    [Inject] private ITagApi TagApi { get; set; }
    [Inject] private NavigationManager Navigation { get; set; }

    public void Dispose()
    {
        Navigation.LocationChanged -= OnLocationChanged;
    }

    protected override void OnInitialized()
    {
        Navigation.LocationChanged += OnLocationChanged;
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
        return Navigation.Uri.Contains(pageName, StringComparison.OrdinalIgnoreCase);
    }

    private void HandleItemsSelected(List<string> selectedItems)
    {
        // Handle the selected items here
    }
}