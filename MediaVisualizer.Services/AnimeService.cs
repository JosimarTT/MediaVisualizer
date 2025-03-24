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

    public async Task<AnimeDto> GetRandom()
    {
        var anime = await _animeRepository.GetRandom();
        return anime.ToDto();
    }

    public Task<List<NewAnime>> SearchNew()
    {
        var newAnimes = Directory.GetFiles(Constants.AnimeDownloadPath).Select(Path.GetFileName).ToList();
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

    public async Task<Stream> StreamAnimeVideo(AnimeDto animeDto, long start, long end)
    {
        var animePath = Path.Combine(Constants.AnimeCollectionPath, animeDto.Folder);

        if (!Directory.Exists(animePath))
            throw new DirectoryNotFoundException($"Anime with title '{animeDto.Title}' not found.");

        var fileName = Path.Combine(animePath, animeDto.Video);
        if (!File.Exists(fileName))
            throw new FileNotFoundException($"Video '{animeDto.Video}' not found.");

        var fileInfo = new FileInfo(fileName);
        var fileLength = fileInfo.Length;

        if (end == 0 || end >= fileLength) end = fileLength - 1;

        var length = end - start + 1;
        var stream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, true);
        stream.Seek(start, SeekOrigin.Begin);

        return new LimitedStream(stream, length);
    }

    public async Task<long> GetVideoLength(AnimeDto animeDto)
    {
        var animePath = Path.Combine(Constants.AnimeCollectionPath, animeDto.Folder);

        if (!Directory.Exists(animePath))
            throw new DirectoryNotFoundException($"Anime with title '{animeDto.Title}' not found.");

        var fileName = Path.Combine(animePath, animeDto.Video);
        if (!File.Exists(fileName))
            throw new FileNotFoundException($"Video '{animeDto.Video}' not found.");

        var fileInfo = new FileInfo(fileName);
        return fileInfo.Length;
    }

    public async Task<VideoMetadataDto> GetVideoMetadata(AnimeDto animeDto)
    {
        var animePath = Path.Combine(Constants.AnimeCollectionPath, animeDto.Folder);

        if (!Directory.Exists(animePath))
            throw new DirectoryNotFoundException($"Anime with title '{animeDto.Title}' not found.");

        var fileName = Path.Combine(animePath, animeDto.Video);
        if (!File.Exists(fileName))
            throw new FileNotFoundException($"Video '{animeDto.Video}' not found.");

        var fileInfo = new FileInfo(fileName);
        var metadata = new VideoMetadataDto
        {
            Length = fileInfo.Length
            // Add other metadata properties here
        };

        return metadata;
    }
}

public interface IAnimeService
{
    public Task<AnimeDto> Get(int animeId);
    public Task<ListResponse<AnimeDto>> GetList(FiltersRequest filters);
    Task<AnimeDto> GetRandom();
    Task<List<NewAnime>> SearchNew();
    Task<IEnumerable<string>> GetTitles();
    Task<AnimeDto> Add(AnimeDto animeDto);
    Task<AnimeDto> Update(int animeId, AnimeDto animeDto);
    Task<Stream> StreamAnimeVideo(AnimeDto animeDto, long start, long end);
    Task<long> GetVideoLength(AnimeDto animeDto);
    Task<VideoMetadataDto> GetVideoMetadata(AnimeDto animeDto);
}