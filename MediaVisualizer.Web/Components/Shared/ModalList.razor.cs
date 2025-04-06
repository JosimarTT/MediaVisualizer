using Blazorise;
using Microsoft.AspNetCore.Components;

namespace MediaVisualizer.Web.Components.Shared;

public partial class ModalList
{
    private List<string> _activeItems = new();
    private Modal _modalRef = null!;

    [Parameter] public string Title { get; set; } = null!;
    [Parameter] public List<string>? Items { get; set; }
    [Parameter] public EventCallback<List<string>> OnItemsSelected { get; set; }

    public Task ShowModal()
    {
        if (_modalRef == null) throw new InvalidOperationException("Modal reference is not set.");
        return _modalRef.Show();
    }

    public Task HideModal()
    {
        if (_modalRef == null) throw new InvalidOperationException("Modal reference is not set.");
        return _modalRef.Hide();
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