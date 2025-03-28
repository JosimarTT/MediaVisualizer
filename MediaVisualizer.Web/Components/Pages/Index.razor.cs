using MediaVisualizer.Web.Api;
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
    [Inject] private IFileStreamApi FileStreamApi { get; set; }

    protected override async Task OnInitializedAsync()
    {
        _isLoading = true;
        var animeTask = AnimeApi.GetRandom();
        var mangaTask = MangaApi.GetRandom();
        var manwhaTask = ManwhaApi.GetRandom();

        await Task.WhenAll(animeTask, mangaTask, manwhaTask);

        var animeDto = await animeTask;
        var mangaDto = await mangaTask;
        var manwhaDto = await manwhaTask;

        _animeImageUrl = FileStreamApi.GetStreamImagePath([animeDto.Logo]);
        _mangaImageUrl =
            FileStreamApi.GetStreamImagePath([mangaDto.Logo], 30);
        _manwhaImageUrl =
            FileStreamApi.GetStreamImagePath([manwhaDto.Logo]);
        _isLoading = false;
    }
}