using MediaVisualizer.Web.Api;
using MediaVisualizer.Web.Helpers;
using Microsoft.AspNetCore.Components;

namespace MediaVisualizer.Web.Components.Pages;

public partial class Index
{
    private string? _animeImageUrl;
    private bool _isLoading = true;
    private string? _mangaImageUrl;
    private string? _manwhaImageUrl;

    [Inject] private IAnimeApi AnimeApi { get; set; }
    [Inject] private IMangaApi MangaApi { get; set; }
    [Inject] private IManwhaApi ManwhaApi { get; set; }
    [Inject] private IBrandApi BrandApi { get; set; }
    [Inject] private IArtistApi ArtistApi { get; set; }
    [Inject] private ITagApi TagApi { get; set; }
    [Inject] private IFileStreamApi FileStreamApi { get; set; }
    [Inject] private PersistentDataHelper PersistentDataHelper { get; set; }


    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (!firstRender) return;

        _isLoading = true;

        var brandsTask = BrandApi.GetList();
        var artistsTask = ArtistApi.GetList();
        var tagsTask = TagApi.GetList();
        var animeTask = AnimeApi.GetRandom();
        var mangaTask = MangaApi.GetRandom();
        var manwhaTask = ManwhaApi.GetRandom();

        await Task.WhenAll(animeTask, mangaTask, manwhaTask, brandsTask, artistsTask, tagsTask);

        var animeDto = await animeTask;
        var mangaDto = await mangaTask;
        var manwhaDto = await manwhaTask;
        PersistentDataHelper.Brands = await brandsTask;
        PersistentDataHelper.Artists = await artistsTask;
        PersistentDataHelper.Tags = await tagsTask;

        _animeImageUrl = FileStreamApi.GetStreamImagePath([animeDto.Logo]);
        _mangaImageUrl =
            FileStreamApi.GetStreamImagePath([mangaDto.Logo], 30);
        _manwhaImageUrl =
            FileStreamApi.GetStreamImagePath([manwhaDto.Logo]);
        _isLoading = false;

        StateHasChanged();
    }
}