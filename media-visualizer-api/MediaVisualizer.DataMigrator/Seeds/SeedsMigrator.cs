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

    public static List<T> ReadExcelFile<T>(string filePath, Func<IXLRangeRow, T> mapRow)
    {
        var list = new List<T>();

        using (var workbook = new XLWorkbook(filePath))
        {
            var worksheet = workbook.Worksheet(1);
            var rows = worksheet.RangeUsed().RowsUsed().Skip(1);

            foreach (var row in rows)
            {
                list.Add(mapRow(row));
            }
        }

        return list;
    }

    public void Migrate()
    {
            var manwhas = ReadExcelFile(@"E:\media-visualizer\media-visualizer-api\MediaVisualizer.DataMigrator\Seeds\Excels\Anime.xlsx", row => new Manwha
            {
                Folder = row.Cell(1).GetValue<string>(),
                Title = row.Cell(2).GetValue<string>(),
                CreatedDate = row.Cell(3).GetValue<DateTime>(),
                UpdatedDate = row.Cell(4).GetValue<DateTime>()
            });

            _dbContext.Manwha.AddRange(manwhas);

            _dbContext.SaveChanges();

    }
}

public interface ISeedsMigrator
{
    void Migrate();
}