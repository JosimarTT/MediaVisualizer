using MediaVisualizer.Shared.Requests;
using MediaVisualizer.Web.Api;
using MediaVisualizer.Web.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace MediaVisualizer.Web.Components.Shared;

public partial class Header : IDisposable
{
    private const string Tags = "Tags";
    private const string Artists = "Artists";
    private const string Brands = "Brands";
    private const string Anime = "Anime";
    private const string Manga = "Manga";
    private const string Manwha = "Manwha";
    private List<string> _artistItems = [];
    private ModalFilter _artistsModalRef = null!;
    private List<string> _brandItems = [];
    private ModalFilter _brandsModalRef = null!;
    private FiltersRequest _filters = new();
    private bool _isModalVisible = false;
    private string _modalTitle = string.Empty;
    private List<string> _tagItems = [];
    private ModalFilter _tagsModalRef = null!;


    private IEnumerable<string> _titles = [];


    [Inject] private IBrandApi BrandApi { get; set; } = null!;
    [Inject] private IArtistApi ArtistApi { get; set; } = null!;
    [Inject] private ITagApi TagApi { get; set; } = null!;
    [Inject] private NavigationManager NavigationManager { get; set; } = null!;
    [Inject] private IFiltersStateService FiltersStateService { get; set; } = null!;
    [Inject] private IAnimeApi AnimeApi { get; set; } = null!;
    [Inject] private IMangaApi MangaApi { get; set; } = null!;
    [Inject] private IManwhaApi ManwhaApi { get; set; } = null!;

    public void Dispose()
    {
        NavigationManager.LocationChanged -= OnLocationChanged!;
    }

    private void HandleSearchChanged(string value)
    {
        _filters.Title = value;
        FiltersStateService.UpdateFilters(_filters);
    }

    protected override void OnInitialized()
    {
        NavigationManager.LocationChanged += OnLocationChanged!;
    }

    protected override async Task OnInitializedAsync()
    {
        _titles = await LoadTitles();
    }

    private async void OnLocationChanged(object sender, LocationChangedEventArgs e)
    {
        _titles = await LoadTitles();
        ClearAllFilters();
        StateHasChanged();
    }

    private async Task<List<string>> LoadTitles()
    {
        if (IsCurrentPage(Anime))
            return await AnimeApi.GetTitlesAsync();
        if (IsCurrentPage(Manga))
            return await MangaApi.GetTitlesAsync();
        if (IsCurrentPage(Manwha))
            return await ManwhaApi.GetTitlesAsync();

        return [];
    }

    private async Task ShowModal(string title)
    {
        _modalTitle = title;
        switch (title)
        {
            case Tags:
                var tags = await TagApi.GetListAsync();
                _tagItems = tags.Select(x => x.Name).ToList();
                await _tagsModalRef.ShowModal();
                break;
            case Artists:
                var artists = await ArtistApi.GetListAsync();
                _artistItems = artists.Select(x => x.Name).ToList();
                await _artistsModalRef.ShowModal();
                break;
            case Brands:
                var brands = await BrandApi.GetListAsync();
                _brandItems = brands.Select(x => x.Name).ToList();
                await _brandsModalRef.ShowModal();
                break;
        }
    }

    private bool IsCurrentPage(string pageName)
    {
        return NavigationManager.Uri.Contains(pageName, StringComparison.OrdinalIgnoreCase);
    }

    private async Task HandleArtistsSearchClicked(List<string> selectedItems)
    {
        var artists = await ArtistApi.GetListAsync();
        var selectedArtists = artists
            .Where(x => selectedItems.Contains(x.Name))
            .Select(x => x.ArtistId)
            .ToList();

        _filters.ArtistIds = selectedArtists;
        FiltersStateService.UpdateFilters(_filters);
    }

    private async Task HandleBrandsSearchClicked(List<string> selectedItems)
    {
        var brands = await BrandApi.GetListAsync();
        var selectedBrands = brands
            .Where(x => selectedItems.Contains(x.Name))
            .Select(x => x.BrandId)
            .ToList();

        _filters.BrandIds = selectedBrands;
        FiltersStateService.UpdateFilters(_filters);
    }

    private async Task HandleTagsSearchClicked(List<string> selectedItems)
    {
        var tags = await TagApi.GetListAsync();
        var selectedTags = tags
            .Where(x => selectedItems.Contains(x.Name))
            .Select(x => x.TagId)
            .ToList();

        _filters.TagIds = selectedTags;
        FiltersStateService.UpdateFilters(_filters);
    }

    private void ClearAllFilters()
    {
        FiltersStateService.ClearFilters();
        _artistsModalRef.ClearFilters();
        _brandsModalRef.ClearFilters();
        _tagsModalRef.ClearFilters();
    }
}