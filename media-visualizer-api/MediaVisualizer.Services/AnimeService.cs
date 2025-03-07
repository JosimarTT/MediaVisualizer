using MediaVisualizer.DataAccess.Repositories;
using MediaVisualizer.DataImporter.Importers;
using MediaVisualizer.Services.Converters;
using MediaVisualizer.Services.Dtos;
using MediaVisualizer.Shared;
using MediaVisualizer.Shared.Dtos;
using MediaVisualizer.Shared.ExtensionMethods;
using MediaVisualizer.Shared.Requests;
using MediaVisualizer.Shared.Responses;

namespace MediaVisualizer.Services;

public class AnimeService : IAnimeService
{
    private readonly IAnimeImporterService _animeImporterService;
    private readonly IAnimeRepository _animeRepository;

    public AnimeService(IAnimeRepository animeRepository, IAnimeImporterService animeImporterService)
    {
        _animeRepository = animeRepository;
        _animeImporterService = animeImporterService;
    }

    public async Task<AnimeDto> Get(int key)
    {
        var anime = await _animeRepository.Get(key);
        return anime.ToDto();
    }

    public async Task<ListResponse<AnimeDto>> GetList(FiltersRequest filters)
    {
        var (totalCount, animes) = await _animeRepository.GetList(filters);
        var animeListDto = animes.ToList().ToListDto();
        return new ListResponse<AnimeDto>(animeListDto, totalCount, filters.Size!.Value, filters.Page!.Value);
    }

    public async Task<AnimeDto> GetRandom()
    {
        var anime = await _animeRepository.GetRandom();
        return anime.ToDto();
    }

    public async Task<List<NewAnime>> SearchNew()
    {
        return await _animeImporterService.SearchNew();
    }

    public async Task<IEnumerable<string>> GetTitles()
    {
        return await _animeRepository.GetTitles();
    }

    public async Task<AnimeDto> Add(AnimeDto animeDto)
    {
        // Store original file paths
        var originalLogoPath = Path.Combine(Constants.AnimeDownloadPath, animeDto.Logo);
        var originalVideoPath = Path.Combine(Constants.AnimeDownloadPath, animeDto.Video);

        // Step 1: Rename the files
        animeDto.Title = animeDto.Title.Trim().RemoveExtraSpaces();
        var baseName = $"{animeDto.Title.ToLower().Replace(" ", "-")}-{animeDto.ChapterNumber}";
        var logoExtension = Path.GetExtension(animeDto.Logo);
        var videoExtension = Path.GetExtension(animeDto.Video);
        animeDto.Folder = animeDto.Title.RemoveInvalidFolderNameChars();
        animeDto.Logo = $"{baseName}{logoExtension}";
        animeDto.Video = $"{baseName}{videoExtension}";

        // Step 2: Move the files to another folder
        var newPath = Path.Combine(Constants.AnimeCollectionPath, animeDto.Folder);
        Directory.CreateDirectory(newPath);
        var newLogoPath = Path.Combine(newPath, animeDto.Logo);
        var newVideoPath = Path.Combine(newPath, animeDto.Video);
        File.Move(originalLogoPath, newLogoPath);
        File.Move(originalVideoPath, newVideoPath);

        var anime = await _animeRepository.Add(animeDto.ToEntity());

        return anime.ToDto();
    }

    public async Task<AnimeDto> Update(int animeId, AnimeDto animeDto)
    {
        var anime = await _animeRepository.Update(animeId, animeDto.ToEntity());
        return anime.ToDto();
    }
}

public interface IAnimeService
{
    public Task<AnimeDto> Get(int key);
    public Task<ListResponse<AnimeDto>> GetList(FiltersRequest filters);
    Task<AnimeDto> GetRandom();
    Task<List<NewAnime>> SearchNew();
    Task<IEnumerable<string>> GetTitles();
    Task<AnimeDto> Add(AnimeDto animeDto);
    Task<AnimeDto> Update(int animeId, AnimeDto animeDto);
}