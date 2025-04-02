namespace MediaVisualizer.Web.Components.Shared;

public partial class Header
{
    private bool isModalVisible = false;
    private List<string> modalItems;
    private ModalList modalListRef;
    private string modalTitle;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
    }

    private async Task ShowModal(string title)
    {
        switch (title)
        {
            case "Tags":
                modalTitle = title;
                modalItems = DataHelper.Tags.Select(x => x.Name).ToList();
                break;
            case "Artists":
                modalTitle = title;
                modalItems = DataHelper.Artists.Select(x => x.Name).ToList();
                break;
            case "Brands":
                modalTitle = title;
                modalItems = DataHelper.Brands.Select(x => x.Name).ToList();
                break;
            default:
                modalTitle = title;
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