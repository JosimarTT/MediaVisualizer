using ClosedXML.Excel;
using MediaVisualizer.DataAccess;
using MediaVisualizer.DataAccess.Entities.Manwha;
using MediaVisualizer.DataAccess.Entities.Shared;

namespace MediaVisualizer.DataMigrator.Seeds;

public class SeedsMigrator: ISeedsMigrator
{
    private readonly MediaVisualizerDbContext _dbContext;

    public SeedsMigrator(MediaVisualizerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public static List<T> ReadCsvFile<T>(string filePath, Func<string[], T> mapRow)
    {
        var list = new List<T>();
        var rows = File.ReadAllLines(filePath).Skip(1).Select(x => x.Split(","));

        foreach (var row in rows)
        {
            list.Add(mapRow(row));
        }

        return list;
    }

    public void Migrate()
    {
        var manwhas = ReadCsvFile(
            @"E:\media-visualizer\media-visualizer-api\MediaVisualizer.DataMigrator\Seeds\CsvFiles\Anime.csv", row =>
                new Manwha
                {
                    Folder = row[0],
                    Title = row[1],
                    CreatedDate = DateTime.Parse(row[2]),
                    UpdatedDate = DateTime.Parse(row[3])
                });

            _dbContext.Manwha.AddRange(manwhas);

            _dbContext.SaveChanges();
    }
}

public interface ISeedsMigrator
{
    void Migrate();
}