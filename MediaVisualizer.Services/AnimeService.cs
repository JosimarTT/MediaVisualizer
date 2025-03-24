using FuzzySharp;
using MediaVisualizer.DataAccess.Repositories;
using MediaVisualizer.Services.Dtos;
using MediaVisualizer.Shared;
using MediaVisualizer.Shared.Dtos;
using MediaVisualizer.Shared.ExtensionMethods;
using MediaVisualizer.Shared.Requests;
using MediaVisualizer.Shared.Responses;

namespace MediaVisualizer.Services;

public class AnimeService : IAnimeService
{
    private readonly IAnimeRepository _animeRepository;

    public AnimeService(IAnimeRepository animeRepository)
    {
        _animeRepository = animeRepository;
    }

    public async Task<AnimeDto> Get(int animeId)
    {
        var anime = await _animeRepository.Get(animeId);
        return anime.ToDto();
    }

    public async Task<ListResponse<AnimeDto>> GetList(FiltersRequest filters)
    {
        var (totalCount, animes) = await _animeRepository.GetList(filters);
        var animeListDto = animes.ToList().ToListDto();
        return new ListResponse<AnimeDto>(animeListDto, totalCount, filters.Size!.Value, filters.Page!.Value);
    }

    public async Task<string> GetRandom()
    {
        var anime = await _animeRepository.GetRandom();

        var animePath = Path.Combine(StringConstants.AnimeCollectionPath, anime.Folder);

        if (!Directory.Exists(animePath))
            throw new DirectoryNotFoundException($"Anime folder '{anime.Folder}' not found.");

        var fileName = Path.Combine(animePath, $"{anime.Logo}");
        if (File.Exists(fileName))
        {
            var fileBytes = await File.ReadAllBytesAsync(fileName);
            var base64String = Convert.ToBase64String(fileBytes);
            return $"data:image/jpeg;base64,{base64String}";
        }

        throw new FileNotFoundException("File not found.");
    }

    public Task<List<NewAnime>> SearchNew()
    {
        var newAnimes = Directory.GetFiles(StringConstants.AnimeDownloadPath).Select(Path.GetFileName).ToList();
        var result = new List<NewAnime>();

        while (newAnimes.Count > 0)
        {
            var currentFile = newAnimes[0];
            var currentFileNameWithoutExtension = Path.GetFileNameWithoutExtension(currentFile);
            var matchFound = false;

            for (var threshold = 80; threshold >= 0; threshold -= 10)
            {
                var match = newAnimes.Skip(1)
                    .FirstOrDefault(y =>
                        Fuzz.Ratio(currentFileNameWithoutExtension, Path.GetFileNameWithoutExtension(y)) > threshold);
                if (match == null) continue;

                result.Add(new NewAnime
                {
                    Logo = currentFile.IsImage() ? currentFile : match,
                    Video = currentFile.IsVideo() ? currentFile : match
                });

                newAnimes.Remove(currentFile);
                newAnimes.Remove(match);
                matchFound = true;
                break;
            }

            if (!matchFound) newAnimes.Remove(currentFile);
        }

        return Task.FromResult(result);
    }

    public async Task<IEnumerable<string>> GetTitles()
    {
        return await _animeRepository.GetTitles();
    }

    public async Task<AnimeDto> Add(AnimeDto animeDto)
    {
        // Store original file paths
        var originalLogoPath = Path.Combine(StringConstants.AnimeDownloadPath, animeDto.Logo);
        var originalVideoPath = Path.Combine(StringConstants.AnimeDownloadPath, animeDto.Video);

        // Step 1: Rename the files
        animeDto.Title = animeDto.Title.Trim().RemoveExtraSpaces();
        var baseName = $"{animeDto.Title.ToLower().Replace(" ", "-")}-{animeDto.ChapterNumber}";
        var logoExtension = Path.GetExtension(animeDto.Logo);
        var videoExtension = Path.GetExtension(animeDto.Video);
        animeDto.Folder = animeDto.Title.RemoveInvalidFolderNameChars();
        animeDto.Logo = $"{baseName}{logoExtension}";
        animeDto.Video = $"{baseName}{videoExtension}";

        // Step 2: Move the files to another folder
        var newPath = Path.Combine(StringConstants.AnimeCollectionPath, animeDto.Folder);
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
    public Task<AnimeDto> Get(int animeId);
    public Task<ListResponse<AnimeDto>> GetList(FiltersRequest filters);
    Task<string> GetRandom();
    Task<List<NewAnime>> SearchNew();
    Task<IEnumerable<string>> GetTitles();
    Task<AnimeDto> Add(AnimeDto animeDto);
    Task<AnimeDto> Update(int animeId, AnimeDto animeDto);
}