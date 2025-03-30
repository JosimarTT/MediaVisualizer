using MediaVisualizer.Services.Dtos;
using MediaVisualizer.Shared.Requests;
using MediaVisualizer.Web.Api;
using Microsoft.AspNetCore.Components;

namespace MediaVisualizer.Web.Components.Pages.Anime;

public partial class AnimeList : IDisposable
{
    private List<AnimeDto> _animeList = new();
    private int _currentPage = 1;
    private bool _isLoading = true;
    private int _totalPages = 1;

    [Inject] private IAnimeApi AnimeApi { get; set; }
    [Inject] private IFileStreamApi FileStreamApi { get; set; }
    [Inject] private AppState AppState { get; set; }

    public void Dispose()
    {
        AppState.OnChange -= OnMyChangeHandler;
    }

    protected override async Task OnInitializedAsync()
    {
        AppState.OnChange += OnMyChangeHandler;
        AppState.EnableButtons(false, true, true);

        await FetchAnimeList(new FiltersRequest { Size = 18, Page = 1 });
    }

    private async Task FetchAnimeList(FiltersRequest filters)
    {
        _isLoading = true;
        var response = await AnimeApi.GetList(filters);
        _animeList = response.Items.ToList();
        foreach (var anime in _animeList)
            anime.Logo = FileStreamApi.GetStreamImagePath([anime.Logo]);
        _totalPages = response.TotalPages;
        _currentPage = filters.Page ?? 1;
        _isLoading = false;
    }

    public async Task OnPageChanged(int newPage)
    {
        _currentPage = newPage;
        await FetchAnimeList(new FiltersRequest { Size = 18, Page = newPage });
    }


    private async void OnMyChangeHandler()
    {
        await InvokeAsync(StateHasChanged);
    }
}