using MediaVisualizer.DataAccess;
using MediaVisualizer.DataAccess.Entities.Anime;
using MediaVisualizer.Shared;
using MediaVisualizer.Shared.ExtensionMethods;

namespace MediaVisualizer.DataImporter;

public class AnimeImporter : IAnimeImporter
{
    private readonly MediaVisualizerDbContext _dbContext;
    private readonly string basePath = Path.Combine(Constants.BaseCollectionFolderPath, Constants.AnimeFolderPath);

    public AnimeImporter(MediaVisualizerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Import()
    {
        if (_dbContext.Animes.Any())
        {
            return;
        }

        var newAnimes = new List<Anime>();
        var dirFiles = Directory.GetFiles(basePath, "*.*", SearchOption.AllDirectories).ToList();
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
                    Video =Path.GetFileName( chapters.FirstOrDefault(x => x.IsVideo()))
                };
                newAnimes.Add(anime);
            }
        }

        try
        {
            await _dbContext.Database.BeginTransactionAsync();
            await _dbContext.Animes.AddRangeAsync(newAnimes);
            await _dbContext.SaveChangesAsync();
            await _dbContext.Database.CommitTransactionAsync();
        }
        catch (Exception e)
        {
            await _dbContext.Database.RollbackTransactionAsync();
            throw;
        }
    }
}

public interface IAnimeImporter
{
    Task Import();
}