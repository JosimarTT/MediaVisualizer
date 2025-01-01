using MediaVisualizer.DataAccess;
using MediaVisualizer.DataAccess.Entities.Manwha;
using MediaVisualizer.Shared;

namespace MediaVisualizer.DataMigrator;

public class ManwhaMigratorRepository : IManwhaMigratorRepository
{
    private readonly MediaVisualizerDbContext _dbContext;
    private readonly string basePath = Path.Combine(Constants.BaseCollectionFolderPath, Constants.ManwhaFolderPath);

    public ManwhaMigratorRepository(MediaVisualizerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Migrate()
    {
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
                        PagesCount = chapterGroup.Count-1,
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
            await _dbContext.Database.BeginTransactionAsync();
            await _dbContext.Manwhas.AddRangeAsync(newManwhas);
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

public interface IManwhaMigratorRepository
{
    Task Migrate();
}