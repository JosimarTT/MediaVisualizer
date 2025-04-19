using MediaVisualizer.Shared.ExtensionMethods;
using MediaVisualizer.Web.Api;
using MediaVisualizer.Web.Constants;
using MediaVisualizer.Web.Services;
using Microsoft.AspNetCore.Components;

namespace MediaVisualizer.Web.Components.Pages;

public partial class Index
{
    private string? _animeImageUrl;
    private bool _isLoading = true;
    private string? _mangaImageUrl;
    private string? _manwhaImageUrl;

    [Inject] private IAnimeApi AnimeApi { get; set; } = null!;
    [Inject] private IMangaApi MangaApi { get; set; } = null!;
    [Inject] private IManwhaApi ManwhaApi { get; set; } = null!;
    [Inject] private IBrandApi BrandApi { get; set; } = null!;
    [Inject] private IArtistApi ArtistApi { get; set; } = null!;
    [Inject] private ITagApi TagApi { get; set; } = null!;
    [Inject] private IFileStreamApi FileStreamApi { get; set; } = null!;
    [Inject] private ISessionStorageService SessionStorageService { get; set; } = null!;


    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (!firstRender) return;

        _isLoading = true;

        var animeTask = AnimeApi.GetRandomAsync();
        var mangaTask = MangaApi.GetRandomAsync();
        var manwhaTask = ManwhaApi.GetRandomAsync();
        var brandTask = BrandApi.GetListAsync();
        var artistTask = ArtistApi.GetListAsync();
        var tagTask = TagApi.GetListAsync();

        await Task.WhenAll(animeTask, mangaTask, manwhaTask, brandTask, artistTask, tagTask);

        var anime = await animeTask;
        var manga = await mangaTask;
        var manwha = await manwhaTask;
        var brands = await brandTask;
        var artists = await artistTask;
        var tags = await tagTask;

        var brandsSessionTask = SessionStorageService.SetItemAsync(StorageConstants.BrandsKey, brands);
        var artistsSessionTask = SessionStorageService.SetItemAsync(StorageConstants.ArtistsKey, artists);
        var tagsSessionTask = SessionStorageService.SetItemAsync(StorageConstants.TagsKey, tags);

        await Task.WhenAll(brandsSessionTask, artistsSessionTask, tagsSessionTask);

        _animeImageUrl = FileStreamApi.GetStreamImagePath(anime.Logo);
        _mangaImageUrl = FileStreamApi.GetStreamImagePath(manga.Logo, 560);
        _manwhaImageUrl = FileStreamApi.GetStreamImagePath(manwha.Logos.GetRandomItem());
        _isLoading = false;

        StateHasChanged();
    }
}