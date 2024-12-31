using MediaVisualizer.DataAccess;
using MediaVisualizer.DataAccess.Entities.Anime;
using MediaVisualizer.Shared.ExtensionMethods;
using Constants = MediaVisualizer.Shared.Constants;

namespace MediaVisualizer.DataMigrator;

public class AnimeMigratorRepository : IAnimeMigratorRepository
{
    private readonly MediaVisualizerDbContext _dbContext;
    private readonly string basePath = Path.Combine(Constants.BaseCollectionFolderPath, Constants.AnimeFolderPath);

    public AnimeMigratorRepository(MediaVisualizerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Migrate()
    {
        var newAnimes = new List<Anime>();
        var directories = Directory.GetDirectories(basePath, "*", SearchOption.AllDirectories);
        var files = directories
            .SelectMany(dir => Directory.GetFiles(dir, "*.*", SearchOption.AllDirectories))
            .ToList();
        var groupedFiles = files
            .GroupBy(file => new DirectoryInfo(Path.GetDirectoryName(file)).Name)
            .ToDictionary(group => group.Key, group => group.Select(file => Path.GetFileName(file)).ToList());

        foreach (var (animeName, chapters) in groupedFiles)
        {
            var anime = new Anime
            {
                Title = animeName,
                Folder = animeName
            };

            var groupedChapters = chapters
                .GroupBy(file => int.Parse(Path.GetFileNameWithoutExtension(file).Split('-').Last()))
                .ToDictionary(group => group.Key, group => group.ToList());

            foreach (var (chapterNumber, chapterGroup) in groupedChapters)
            {
                var chapter = new AnimeChapter
                {
                    ChapterNumber = chapterNumber,
                    Logo = chapterGroup.First(file => file.IsImage()),
                    Video = chapterGroup.First(file => file.IsVideo())
                };

                anime.AnimeChapters.Add(chapter);
            }

            newAnimes.Add(anime);
        }

        try
        {
            _dbContext.Database.BeginTransactionAsync();
            _dbContext.Animes.AddRangeAsync(newAnimes);
            await _dbContext.SaveChangesAsync();
            _dbContext.Database.CommitTransactionAsync();
        }
        catch (Exception e)
        {
            _dbContext.Database.RollbackTransactionAsync();
            throw;
        }
    }
}

public interface IAnimeMigratorRepository
{
    Task Migrate();
}