using MediaVisualizer.DataAccess;
using MediaVisualizer.DataAccess.Entities.Manga;
using MediaVisualizer.Shared;

namespace MediaVisualizer.DataImporter;

public class MangaImporterRepository : IMangaImporterRepository
{
    private readonly MediaVisualizerDbContext _dbContext;
    private readonly string basePath = Path.Combine(Constants.BaseCollectionFolderPath, Constants.MangaFolderPath);

    public MangaImporterRepository(MediaVisualizerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Migrate()
    {
        if (_dbContext.Mangas.Any())
        {
            return;
        }

        var mangas = new List<Manga>();

        foreach (var folder in Constants.MangaFolders)
        {
            var folderPath = Path.Combine(basePath, folder);
            if (Directory.Exists(folderPath))
            {
                var files = Directory.GetFiles(folderPath, "*.*", SearchOption.AllDirectories)
                    .Where(file => Constants.ImageExtensions.Contains(Path.GetExtension(file)))
                    .ToList();
                var groupedFiles = files
                    .GroupBy(file => new DirectoryInfo(Path.GetDirectoryName(file)).Name)
                    .ToDictionary(group => group.Key, group => group.Select(file => Path.GetFileName(file)).ToList());

                foreach (var (mangaFolder, pages) in groupedFiles)
                {
                    var manga = new Manga
                    {
                        Title = mangaFolder,
                        Folder = $"{folder}\\{mangaFolder}"
                    };

                    var mangaChapter = new MangaChapter
                    {
                        ChapterNumber = 1,
                        PagesCount = pages.Count,
                        Logo = pages.First(),
                        PageExtension = Path.GetExtension(pages.First())
                    };
                    manga.MangaChapters.Add(mangaChapter);
                    mangas.Add(manga);
                }
            }
        }

        try
        {
            await _dbContext.Database.BeginTransactionAsync();
            await _dbContext.Mangas.AddRangeAsync(mangas);
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

public interface IMangaImporterRepository
{
    Task Migrate();
}