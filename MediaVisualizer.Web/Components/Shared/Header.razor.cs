using MediaVisualizer.Web.Api;
using Microsoft.AspNetCore.Components;

namespace MediaVisualizer.Web.Components.Shared;

public partial class Header
{
    private bool isModalVisible = false;
    private List<string> modalItems;
    private ModalList modalListRef;
    private string modalTitle;

    [Inject] private IBrandApi BrandApi { get; set; }
    [Inject] private IArtistApi ArtistApi { get; set; }
    [Inject] private ITagApi TagApi { get; set; }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        StateHasChanged();
    }

    private async Task ShowModal(string title)
    {
        modalTitle = title;
        switch (title)
        {
            case "Tags":
            {
                var tags = await TagApi.GetList();
                modalItems = tags.Select(x => x.Name).ToList();
                break;
            }

            case "Artists":
            {
                var artists = await ArtistApi.GetList();
                modalItems = artists.Select(x => x.Name).ToList();
                break;
            }
            case "Brands":
            {
                var brands = await BrandApi.GetList();
                modalItems = brands.Select(x => x.Name).ToList();
                break;
            }

            default:
                modalItems = [];
                break;
        }

        await modalListRef.Show();
    }

    private bool IsCurrentPage(string pageName)
    {
        return Navigation.Uri.Contains(pageName, StringComparison.OrdinalIgnoreCase);
    }
}