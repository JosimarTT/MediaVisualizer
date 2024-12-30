using ClosedXML.Excel;
using MediaVisualizer.DataAccess;
using MediaVisualizer.DataAccess.Entities.Anime;
using MediaVisualizer.DataAccess.Entities.Manga;
using MediaVisualizer.DataAccess.Entities.Manwha;
using MediaVisualizer.DataAccess.Entities.Shared;
using MediaVisualizer.Shared;

namespace MediaVisualizer.DataMigrator.Seeds;

public class SeedsMigrator : ISeedsMigrator
{
    private readonly MediaVisualizerDbContext _dbContext;

    public SeedsMigrator(MediaVisualizerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async static Task<List<T>> ReadCsvFile<T>(string filePath, Func<string[], T> mapRow)
    {
        var lines = await File.ReadAllLinesAsync(filePath);
        var rows = lines.Skip(1).Select(x => x.Split(","));

        return rows.Select(row => mapRow(row)).ToList();
    }

    public async Task Migrate()
    {
        var manwhasTask = ReadCsvFile(Path.Combine(Constants.BaseCsvFilesPath, Constants.ManwhaCsvFilePath), row =>
            new Manwha
            {
                Folder = row[0],
                Title = row[1],
                CreatedDate = DateTime.Parse(row[2]),
                UpdatedDate = DateTime.Parse(row[3])
            });

        var animesTask = ReadCsvFile(Path.Combine(Constants.BaseCsvFilesPath, Constants.AnimeCsvFilePath), row =>
            new Anime
            {
                Folder = row[0],
                Title = row[1],
                CreatedDate = DateTime.Parse(row[2]),
                UpdatedDate = DateTime.Parse(row[3])
            });

        var mangasTask = ReadCsvFile(Path.Combine(Constants.BaseCsvFilesPath, Constants.MangaCsvFilePath), row =>
            new Manga
            {
                Folder = row[0],
                Title = row[1],
                CreatedDate = DateTime.Parse(row[2]),
                UpdatedDate = DateTime.Parse(row[3])
            });

        var tagsTask = ReadCsvFile(Path.Combine(Constants.BaseCsvFilesPath, Constants.TagCsvFilePath), row =>
            new Tag
            {
                Name = row[0],
                CreatedDate = DateTime.Parse(row[1]),
                UpdatedDate = DateTime.Parse(row[2])
            });

        var brandsTask = ReadCsvFile(Path.Combine(Constants.BaseCsvFilesPath, Constants.BrandCsvFilePath), row =>
            new Brand
            {
                Name = row[0],
                CreatedDate = DateTime.Parse(row[1]),
                UpdatedDate = DateTime.Parse(row[2])
            });

        var authorsTask = ReadCsvFile(Path.Combine(Constants.BaseCsvFilesPath, Constants.AuthorCsvFilePath), row =>
            new Author
            {
                Name = row[0],
                CreatedDate = DateTime.Parse(row[1]),
                UpdatedDate = DateTime.Parse(row[2])
            });

        var artistsTask = ReadCsvFile(Path.Combine(Constants.BaseCsvFilesPath, Constants.ArtistCsvFilePath), row =>
            new Artist
            {
                Name = row[0],
                CreatedDate = DateTime.Parse(row[1]),
                UpdatedDate = DateTime.Parse(row[2])
            });

        var animeChaptersTask = ReadCsvFile(Path.Combine(Constants.BaseCsvFilesPath, Constants.AnimeChapterCsvFilePath),
            row =>
                new AnimeChapter
                {
                    AnimeChapterId = int.Parse(row[0]),
                    AnimeId = int.Parse(row[1]),
                    ChapterNumber = int.Parse(row[2]),
                    Logo = row[3],
                    CreatedDate = DateTime.Parse(row[4]),
                    UpdatedDate = DateTime.Parse(row[5])
                });

        var mangaChaptersTask = ReadCsvFile(Path.Combine(Constants.BaseCsvFilesPath, Constants.MangaChapterCsvFilePath),
            row =>
                new MangaChapter
                {
                    MangaChapterId = int.Parse(row[0]),
                    MangaId =  int.Parse(row[1]),
                    ChapterNumber = int.Parse(row[2]),
                    Logo = row[3],
                    CreatedDate = DateTime.Parse(row[4]),
                    UpdatedDate = DateTime.Parse(row[5]),
                    PagesCount = int.Parse(row[6])
                });

        var manwhaChaptersTask = ReadCsvFile(
            Path.Combine(Constants.BaseCsvFilesPath, Constants.ManwhaChapterCsvFilePath), row =>
                new ManwhaChapter
                {
                    ManwhaChapterId = int.Parse(row[0]),
                    ManwhaId = int.Parse(row[1]),
                    ChapterNumber = int.Parse(row[2]),
                    Logo = row[3],
                    CreatedDate = DateTime.Parse(row[4]),
                    UpdatedDate = DateTime.Parse(row[5]),
                    PagesCount = int.Parse(row[6])
                });



        await Task.WhenAll(manwhasTask, animesTask, mangasTask, tagsTask, brandsTask, authorsTask, artistsTask,
            animeChaptersTask, mangaChaptersTask, manwhaChaptersTask);

        var manwhas = await manwhasTask;
        var animes = await animesTask;
        var mangas = await mangasTask;
        var tags = await tagsTask;
        var brands = await brandsTask;
        var authors = await authorsTask;
        var artists = await artistsTask;
        var animeChapters = await animeChaptersTask;
        var mangaChapters = await mangaChaptersTask;
        var manwhaChapters = await manwhaChaptersTask;

        try
        {
            await _dbContext.Database.BeginTransactionAsync();

            _dbContext.Animes.AddRange(animes);
            _dbContext.Mangas.AddRange(mangas);
            _dbContext.Manwhas.AddRange(manwhas);
            _dbContext.Tags.AddRange(tags);
            _dbContext.Brands.AddRange(brands);
            _dbContext.Authors.AddRange(authors);
            _dbContext.Artists.AddRange(artists);
            await _dbContext.SaveChangesAsync();

            _dbContext.AnimeChapters.AddRange(animeChapters);
            _dbContext.MangaChapters.AddRange(mangaChapters);
            _dbContext.ManwhaChapters.AddRange(manwhaChapters);
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

public interface ISeedsMigrator
{
    Task Migrate();
}