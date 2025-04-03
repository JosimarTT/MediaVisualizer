using Blazorise;
using Microsoft.AspNetCore.Components;

namespace MediaVisualizer.Web.Components.Shared;

public partial class ModalList
{
    private List<string> _activeItems = [];
    private Modal _modalRef = null!;

    [Parameter] public string Title { get; set; } = null!;
    [Parameter] public List<string>? Items { get; set; }
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
        if (!_activeItems.Remove(item))
            _activeItems.Add(item);
    }

    private void ClearFilters()
    {
        _activeItems.Clear();
    }
}