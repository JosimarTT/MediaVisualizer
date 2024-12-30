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
                    AnimeChapterKey = int.Parse(row[0]),
                    AnimeKey = int.Parse(row[1]),
                    ChapterNumber = int.Parse(row[2]),
                    Logo = row[3],
                    CreatedDate = DateTime.Parse(row[4]),
                    UpdatedDate = DateTime.Parse(row[5])
                });

        var mangaChaptersTask = ReadCsvFile(Path.Combine(Constants.BaseCsvFilesPath, Constants.MangaChapterCsvFilePath),
            row =>
                new MangaChapter
                {
                    MangaChapterKey = int.Parse(row[0]),
                    MangaKey = int.Parse(row[1]),
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
                    ManwhaChapterKey = int.Parse(row[0]),
                    ManwhaKey = int.Parse(row[1]),
                    ChapterNumber = int.Parse(row[2]),
                    Logo = row[3],
                    CreatedDate = DateTime.Parse(row[4]),
                    UpdatedDate = DateTime.Parse(row[5]),
                    PagesCount = int.Parse(row[6])
                });

        var animeTagsTask = ReadCsvFile(Path.Combine(Constants.BaseCsvFilesPath, Constants.AnimeTagCsvFilePath), row =>
            new AnimeTag
            {
                AnimeKey = int.Parse(row[0]),
                TagKey = int.Parse(row[1]),
                CreatedDate = DateTime.Parse(row[2]),
                UpdatedDate = DateTime.Parse(row[3])
            });

        var mangaTagsTask = ReadCsvFile(Path.Combine(Constants.BaseCsvFilesPath, Constants.MangaTagCsvFilePath), row =>
            new MangaTag
            {
                MangaKey = int.Parse(row[0]),
                TagKey = int.Parse(row[1]),
                CreatedDate = DateTime.Parse(row[2]),
                UpdatedDate = DateTime.Parse(row[3])
            });

        var manwhaTagsTask = ReadCsvFile(Path.Combine(Constants.BaseCsvFilesPath, Constants.ManwhaTagCsvFilePath),
            row =>
                new ManwhaTag
                {
                    ManwhaKey = int.Parse(row[0]),
                    TagKey = int.Parse(row[1]),
                    CreatedDate = DateTime.Parse(row[2]),
                    UpdatedDate = DateTime.Parse(row[3])
                });

        var animeBrandsTask = ReadCsvFile(Path.Combine(Constants.BaseCsvFilesPath, Constants.AnimeBrandCsvFilePath),
            row =>
                new AnimeBrand
                {
                    AnimeKey = int.Parse(row[0]),
                    BrandKey = int.Parse(row[1]),
                    CreatedDate = DateTime.Parse(row[2]),
                    UpdatedDate = DateTime.Parse(row[3])
                });

        var mangaBrandsTask = ReadCsvFile(Path.Combine(Constants.BaseCsvFilesPath, Constants.MangaBrandCsvFilePath),
            row =>
                new MangaBrand
                {
                    MangaKey = int.Parse(row[0]),
                    BrandKey = int.Parse(row[1]),
                    CreatedDate = DateTime.Parse(row[2]),
                    UpdatedDate = DateTime.Parse(row[3])
                });

        var manwhaBrandsTask = ReadCsvFile(Path.Combine(Constants.BaseCsvFilesPath, Constants.ManwhaBrandCsvFilePath),
            row =>
                new ManwhaBrand
                {
                    ManwhaKey = int.Parse(row[0]),
                    BrandKey = int.Parse(row[1]),
                    CreatedDate = DateTime.Parse(row[2]),
                    UpdatedDate = DateTime.Parse(row[3])
                });

        var mangaAuthorsTask = ReadCsvFile(Path.Combine(Constants.BaseCsvFilesPath, Constants.MangaAuthorCsvFilePath),
            row =>
                new MangaAuthor
                {
                    MangaKey = int.Parse(row[0]),
                    AuthorKey = int.Parse(row[1]),
                    CreatedDate = DateTime.Parse(row[2]),
                    UpdatedDate = DateTime.Parse(row[3])
                });

        var manwhaAuthorsTask = ReadCsvFile(Path.Combine(Constants.BaseCsvFilesPath, Constants.ManwhaAuthorCsvFilePath),
            row =>
                new ManwhaAuthor
                {
                    ManwhaKey = int.Parse(row[0]),
                    AuthorKey = int.Parse(row[1]),
                    CreatedDate = DateTime.Parse(row[2]),
                    UpdatedDate = DateTime.Parse(row[3])
                });

        var mangaArtistsTask = ReadCsvFile(Path.Combine(Constants.BaseCsvFilesPath, Constants.MangaArtistCsvFilePath),
            row =>
                new MangaArtist
                {
                    MangaKey = int.Parse(row[0]),
                    ArtistKey = int.Parse(row[1]),
                    CreatedDate = DateTime.Parse(row[2]),
                    UpdatedDate = DateTime.Parse(row[3])
                });

        var manwhaArtistsTask = ReadCsvFile(Path.Combine(Constants.BaseCsvFilesPath, Constants.ManwhaArtistCsvFilePath),
            row =>
                new ManwhaArtist
                {
                    ManwhaKey = int.Parse(row[0]),
                    ArtistKey = int.Parse(row[1]),
                    CreatedDate = DateTime.Parse(row[2]),
                    UpdatedDate = DateTime.Parse(row[3])
                });

        await Task.WhenAll(manwhasTask, animesTask, mangasTask, tagsTask, brandsTask, authorsTask, artistsTask,
            animeChaptersTask, mangaChaptersTask, manwhaChaptersTask, animeTagsTask, mangaTagsTask, manwhaTagsTask,
            animeBrandsTask, mangaBrandsTask, manwhaBrandsTask, mangaAuthorsTask, manwhaAuthorsTask, mangaArtistsTask,
            manwhaArtistsTask);

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
        var animeTags = await animeTagsTask;
        var mangaTags = await mangaTagsTask;
        var manwhaTags = await manwhaTagsTask;
        var animeBrands = await animeBrandsTask;
        var mangaBrands = await mangaBrandsTask;
        var manwhaBrands = await manwhaBrandsTask;
        var mangaAuthors = await mangaAuthorsTask;
        var manwhaAuthors = await manwhaAuthorsTask;
        var mangaArtists = await mangaArtistsTask;
        var manwhaArtists = await manwhaArtistsTask;

        try
        {
            await _dbContext.Database.BeginTransactionAsync();

            _dbContext.Anime.AddRange(animes);
            _dbContext.Manga.AddRange(mangas);
            _dbContext.Manwha.AddRange(manwhas);
            _dbContext.Tag.AddRange(tags);
            _dbContext.Brand.AddRange(brands);
            _dbContext.Author.AddRange(authors);
            _dbContext.Artist.AddRange(artists);
            await _dbContext.SaveChangesAsync();

            _dbContext.AnimeChapter.AddRange(animeChapters);
            _dbContext.MangaChapter.AddRange(mangaChapters);
            _dbContext.ManwhaChapter.AddRange(manwhaChapters);
            _dbContext.AnimeTag.AddRange(animeTags);
            _dbContext.MangaTag.AddRange(mangaTags);
            _dbContext.ManwhaTag.AddRange(manwhaTags);
            _dbContext.AnimeBrand.AddRange(animeBrands);
            _dbContext.MangaBrand.AddRange(mangaBrands);
            _dbContext.ManwhaBrand.AddRange(manwhaBrands);
            _dbContext.MangaAuthor.AddRange(mangaAuthors);
            _dbContext.ManwhaAuthor.AddRange(manwhaAuthors);
            _dbContext.MangaArtist.AddRange(mangaArtists);
            _dbContext.ManwhaArtist.AddRange(manwhaArtists);
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