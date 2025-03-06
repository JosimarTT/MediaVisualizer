using MediaVisualizer.DataAccess;
using MediaVisualizer.DataAccess.Entities;
using MediaVisualizer.Shared;

namespace MediaVisualizer.DataImporter.Importers;

public class MangaImporter
{
    private readonly MediaVisualizerDbContext _context;
    private readonly string basePath = Path.Combine(Constants.BaseCollectionPath, Constants.MangaFolderPath);

    public MangaImporter(MediaVisualizerDbContext context)
    {
        _context = context;
    }

    public async Task ImportData()
    {
        if (_context.Mangas.Any()) return;

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
                        Folder = $"{folder}\\{mangaFolder}",
                        Title = mangaFolder,
                        ChapterNumber = 1,
                        PagesCount = pages.Count,
                        Logo = pages.First(),
                        PageExtension = Path.GetExtension(pages.First())
                    };
                    mangas.Add(manga);
                }
            }
        }

        try
        {
            await _context.Database.BeginTransactionAsync();
            await _context.Mangas.AddRangeAsync(mangas);
            await _context.SaveChangesAsync();
            await _context.Database.CommitTransactionAsync();
        }
        catch (Exception e)
        {
            await _context.Database.RollbackTransactionAsync();
            throw;
        }
    }
}