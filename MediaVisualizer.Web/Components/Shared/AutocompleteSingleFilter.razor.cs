using Blazorise.Components;
using Microsoft.AspNetCore.Components;

namespace MediaVisualizer.Web.Components.Shared;

public partial class AutocompleteSingleFilter : ComponentBase
{
    private Autocomplete<string, string>? _autocompleteRef;
    private string _selectedText = string.Empty;
    private string _selectedValue = string.Empty;

    [Parameter] public IEnumerable<string> Items { get; set; } = [];
    [Parameter] public EventCallback<string> OnSearchChanged { get; set; }

    private async Task HandleSearchChanged(string searchText)
    {
        await OnSearchChanged.InvokeAsync(searchText);
    }

    public void ClearSearch()
    {
        _autocompleteRef?.Clear();
        StateHasChanged();
    }
}