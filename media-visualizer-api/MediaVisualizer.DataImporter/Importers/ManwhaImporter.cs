using MediaVisualizer.DataAccess;
using MediaVisualizer.DataAccess.Entities;
using MediaVisualizer.Shared;

namespace MediaVisualizer.DataImporter.Importers;

public class ManwhaImporter
{
    private readonly MediaVisualizerDbContext _context;
    private readonly string basePath = Path.Combine(Constants.BaseCollectionFolderPath, Constants.ManwhaFolderPath);

    public ManwhaImporter(MediaVisualizerDbContext context)
    {
        _context = context;
    }

    public async Task ImportData()
    {
        if (_context.Manwhas.Any())
        {
            return;
        }

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
                    if (fileName.StartsWith("logo"))
                    {
                        return "logo";
                    }

                    return fileName.Split('-')[0];
                })
                .ToDictionary(group => group.Key, group => group.ToList());

            foreach (var (chapterNumber, chapterGroup) in groupedChapters)
            {
                if (chapterNumber == "logo")
                {
                    manwha.Logos = System.Text.Json.JsonSerializer.Serialize(chapterGroup);
                }
                else
                {
                    var chapter = new ManwhaChapter
                    {
                        ChapterNumber = int.Parse(chapterNumber),
                        PagesCount = chapterGroup.Count - 1,
                        Logo = chapterGroup.First(file =>
                            Path.GetFileNameWithoutExtension(file).Split('-')[1] == "0"),
                        PageExtension = Path.GetExtension(chapterGroup.First(file =>
                            Path.GetFileNameWithoutExtension(file).Split('-')[1] != "0"))
                    };

                    manwha.ManwhaChapters.Add(chapter);
                }
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
        catch (Exception e)
        {
            await _context.Database.RollbackTransactionAsync();
            throw;
        }
    }
}