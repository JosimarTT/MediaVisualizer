using FuzzySharp;
using MediaVisualizer.DataAccess;
using MediaVisualizer.DataAccess.Entities.Anime;
using MediaVisualizer.Shared;
using MediaVisualizer.Shared.Dtos;
using MediaVisualizer.Shared.ExtensionMethods;

namespace MediaVisualizer.DataImporter.Importers;

public class AnimeImporterService : IAnimeImporterService
{
    private readonly string _collectionPath =
        Path.Combine(StringConstants.BaseCollectionPath, StringConstants.AnimeFolderPath);

    private readonly MediaVisualizerDbContext _context;

    private readonly string _downloadPath =
        Path.Combine(StringConstants.BaseDownloadPath, StringConstants.AnimeFolderPath);

    public AnimeImporterService(MediaVisualizerDbContext context)
    {
        _context = context;
    }

    public async Task ImportData()
    {
        if (_context.Animes.Any()) return;

        var newAnimes = new List<Anime>();
        var dirFiles = Directory.GetFiles(_collectionPath, "*.*", SearchOption.AllDirectories).ToList();
        var groupedFiles = dirFiles
            .GroupBy(file => new DirectoryInfo(Path.GetDirectoryName(file)).Name)
            .ToDictionary(group => group.Key, group => group.ToList());

        foreach (var (folder, files) in groupedFiles)
        {
            var groupedChapters = files
                .GroupBy(file => int.Parse(Path.GetFileNameWithoutExtension(file).Split('-').Last()))
                .ToDictionary(group => group.Key, group => group.ToList());

            foreach (var (chapterNumber, chapters) in groupedChapters)
            {
                var anime = new Anime
                {
                    Folder = folder,
                    Title = folder,
                    ChapterNumber = chapterNumber,
                    Logo = Path.GetFileName(chapters.FirstOrDefault(x => x.IsImage())),
                    Video = Path.GetFileName(chapters.FirstOrDefault(x => x.IsVideo()))
                };
                newAnimes.Add(anime);
            }
        }

        try
        {
            await _context.Database.BeginTransactionAsync();
            await _context.Animes.AddRangeAsync(newAnimes);
            await _context.SaveChangesAsync();
            await _context.Database.CommitTransactionAsync();
        }
        catch (Exception e)
        {
            await _context.Database.RollbackTransactionAsync();
            throw;
        }
    }

    public Task<List<NewAnime>> SearchNew()
    {
        var newAnimes = Directory.GetFiles(_downloadPath).Select(Path.GetFileName).ToList();
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
}

public interface IAnimeImporterService
{
    public Task ImportData();
    public Task<List<NewAnime>> SearchNew();
}