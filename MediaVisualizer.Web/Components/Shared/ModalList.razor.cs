using Blazorise;
using Microsoft.AspNetCore.Components;

namespace MediaVisualizer.Web.Components.Shared;

public partial class ModalList
{
    private List<string> activeItems = [];
    private Modal modalRef;

    [Parameter] public string Title { get; set; }
    [Parameter] public List<string> Items { get; set; }
    [Parameter] public bool IsVisible { get; set; }
    [Parameter] public EventCallback<bool> IsVisibleChanged { get; set; }

    public async Task Show()
    {
        IsVisible = true;
        await IsVisibleChanged.InvokeAsync(IsVisible);
    }

    private async Task Hide()
    {
        IsVisible = false;
        await IsVisibleChanged.InvokeAsync(IsVisible);
    }

    private void ToggleFilter(string item)
    {
        if (!activeItems.Remove(item))
            activeItems.Add(item);
    }

    private void ClearFilters()
    {
        activeItems.Clear();
    }
}