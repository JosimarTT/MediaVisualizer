using MediaVisualizer.Web.Api;
using MediaVisualizer.Web.Constants;
using MediaVisualizer.Web.Storage;
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

        var animeTask = AnimeApi.GetRandom();
        var mangaTask = MangaApi.GetRandom();
        var manwhaTask = ManwhaApi.GetRandom();
        var brandTask = BrandApi.GetList();
        var artistTask = ArtistApi.GetList();
        var tagTask = TagApi.GetList();

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
        _manwhaImageUrl = FileStreamApi.GetStreamImagePath(manwha.Logo);
        _isLoading = false;

        StateHasChanged();
    }
}