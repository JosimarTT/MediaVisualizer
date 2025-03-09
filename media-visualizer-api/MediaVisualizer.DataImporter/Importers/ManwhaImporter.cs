using MediaVisualizer.DataAccess;
using MediaVisualizer.DataAccess.Entities.Manwha;
using MediaVisualizer.Shared;

namespace MediaVisualizer.DataImporter.Importers;

public class ManwhaImporter
{
    private readonly MediaVisualizerDbContext _context;
    private readonly string basePath = Path.Combine(Constants.BaseCollectionPath, Constants.ManwhaFolderPath);

    public ManwhaImporter(MediaVisualizerDbContext context)
    {
        _context = context;
    }

    public async Task ImportData()
    {
        if (_context.Manwhas.Any()) return;

        var newManwhas = new List<Manwha>();
        var files = Directory.GetFiles(basePath, "*.*", SearchOption.AllDirectories).ToList();
        var groupedFiles = files
            .GroupBy(file => new DirectoryInfo(Path.GetDirectoryName(file)).Name)
            .ToDictionary(group => group.Key, group => group.Select(file => Path.GetFileName(file)).ToList());

        foreach (var (folder, chapters) in groupedFiles)
        {
            var manwha = new Manwha
            {
                Title = folder,
                Folder = folder
            };

            var groupedChapters = chapters
                .GroupBy(file =>
                {
                    var fileName = Path.GetFileNameWithoutExtension(file);
                    if (fileName.StartsWith("logo")) return "logo";

                    return fileName.Split('-')[0];
                })
                .ToDictionary(group => group.Key, group => group.ToList());

            foreach (var (chapterNumber, chapterGroup) in groupedChapters)
                if (chapterNumber == "logo")
                {
                    manwha.Logo = chapterGroup.First();
                }
                else
                {
                    manwha.ChapterNumber = int.Parse(chapterNumber);
                    manwha.PagesCount = chapterGroup.Count - 1;
                    manwha.PageExtension = Path.GetExtension(chapterGroup.First(file =>
                        Path.GetFileNameWithoutExtension(file).Split('-')[1] != "0"));
                }

            newManwhas.Add(manwha);
        }

        try
        {
            await _context.Database.BeginTransactionAsync();
            await _context.Manwhas.AddRangeAsync(newManwhas);
            await _context.SaveChangesAsync();
            await _context.Database.CommitTransactionAsync();
        }
        catch (Exception)
        {
            await _context.Database.RollbackTransactionAsync();
            throw;
        }
    }
}