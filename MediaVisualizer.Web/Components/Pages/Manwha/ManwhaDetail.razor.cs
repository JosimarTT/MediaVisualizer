using Microsoft.AspNetCore.Components;

namespace MediaVisualizer.Web.Components.Pages.Manwha;

public partial class ManwhaDetail : IDisposable
{
    [Inject] private AppState AppState { get; set; }

    public void Dispose()
    {
        AppState.OnChange += OnMyChangeHandler;
    }

    protected override async Task OnInitializedAsync()
    {
        AppState.OnChange += OnMyChangeHandler;
        AppState.EnableButtons(true, false, true);
    }

    private async void OnMyChangeHandler()
    {
        await InvokeAsync(StateHasChanged);
    }
}