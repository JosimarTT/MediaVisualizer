using Blazorise;
using MediaVisualizer.Web.Services;
using Microsoft.AspNetCore.Components;

namespace MediaVisualizer.Web.Components.Shared;

public partial class ModalList
{
    private List<string> _activeItems = [];
    private Modal _modalRef = null!;

    [Parameter] public string Title { get; set; } = null!;
    [Parameter] public List<string>? Items { get; set; }
    [Parameter] public EventCallback<List<string>> OnSearchClicked { get; set; }

    [Inject] private ISessionStorageService SessionStorageService { get; set; } = null!;
    [Inject] private IFiltersStateService FiltersStateService { get; set; } = null!;

    public Task ShowModal()
    {
        return _modalRef.Show();
    }

    private Task HideModal()
    {
        return _modalRef.Hide();
    }

    private void ToggleItemSelected(string item)
    {
        if (!_activeItems.Remove(item))
            _activeItems.Add(item);
    }

    private void ClearFilters()
    {
        _activeItems.Clear();
    }

    private async Task TriggerSearch()
    {
        await OnSearchClicked.InvokeAsync(_activeItems);
        await _modalRef.Hide();
    }
}