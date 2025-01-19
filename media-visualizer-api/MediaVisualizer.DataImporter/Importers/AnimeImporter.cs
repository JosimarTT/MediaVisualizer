using MediaVisualizer.DataAccess;
using MediaVisualizer.DataAccess.Entities;
using MediaVisualizer.Shared;
using MediaVisualizer.Shared.ExtensionMethods;

namespace MediaVisualizer.DataImporter.Importers;

public class AnimeImporter
{
    private readonly MediaVisualizerDbContext _context;
    private readonly string basePath = Path.Combine(Constants.BaseCollectionFolderPath, Constants.AnimeFolderPath);

    public AnimeImporter(MediaVisualizerDbContext context)
    {
        _context = context;
    }

    public async Task ImportData()
    {
        if (_context.Animes.Any())
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
}