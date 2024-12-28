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
        var manwhas = ReadCsvFile(Path.Combine(Constants.BaseCsvFilesPath, Constants.ManwhaCsvFilePath), row =>
            new Manwha
            {
                Folder = row[0],
                Title = row[1],
                CreatedDate = DateTime.Parse(row[2]),
                UpdatedDate = DateTime.Parse(row[3])
            });

        var animes = ReadCsvFile(Path.Combine(Constants.BaseCsvFilesPath, Constants.AnimeCsvFilePath), row =>
            new Anime
            {
                Folder = row[0],
                Title = row[1],
                CreatedDate = DateTime.Parse(row[2]),
                UpdatedDate = DateTime.Parse(row[3])
            });

        var mangas = ReadCsvFile(Path.Combine(Constants.BaseCsvFilesPath, Constants.MangaCsvFilePath), row =>
            new Manga
            {
                Folder = row[0],
                Title = row[1],
                CreatedDate = DateTime.Parse(row[2]),
                UpdatedDate = DateTime.Parse(row[3])
            });

        var tags = ReadCsvFile(Path.Combine(Constants.BaseCsvFilesPath, Constants.TagCsvFilePath), row =>
            new Tag
            {
                Name = row[0],
                CreatedDate = DateTime.Parse(row[1]),
                UpdatedDate = DateTime.Parse(row[2])
            });

        var brands = ReadCsvFile(Path.Combine(Constants.BaseCsvFilesPath, Constants.BrandCsvFilePath), row =>
            new Brand
            {
                Name = row[0],
                CreatedDate = DateTime.Parse(row[1]),
                UpdatedDate = DateTime.Parse(row[2])
            });

        var authors = ReadCsvFile(Path.Combine(Constants.BaseCsvFilesPath, Constants.AuthorCsvFilePath), row =>
            new Author
            {
                Name = row[0],
                CreatedDate = DateTime.Parse(row[1]),
                UpdatedDate = DateTime.Parse(row[2])
            });

        var artists = ReadCsvFile(Path.Combine(Constants.BaseCsvFilesPath, Constants.ArtistCsvFilePath), row =>
            new Artist
            {
                Name = row[0],
                CreatedDate = DateTime.Parse(row[1]),
                UpdatedDate = DateTime.Parse(row[2])
            });

        var animeChapters = ReadCsvFile(
            Path.Combine(Constants.BaseCsvFilesPath, Constants.AnimeChapterCsvFilePath), row => new AnimeChapter
            {
                AnimeChapterKey = int.Parse(row[0]),
                AnimeKey = int.Parse(row[1]),
                ChapterNumber = int.Parse(row[2]),
                Logo = row[3],
                CreatedDate = DateTime.Parse(row[4]),
                UpdatedDate = DateTime.Parse(row[5])
            });

        var mangaChapters = ReadCsvFile(
            Path.Combine(Constants.BaseCsvFilesPath, Constants.MangaChapterCsvFilePath), row => new MangaChapter
            {
                MangaChapterKey = int.Parse(row[0]),
                MangaKey = int.Parse(row[1]),
                ChapterNumber = int.Parse(row[2]),
                Logo = row[3],
                CreatedDate = DateTime.Parse(row[4]),
                UpdatedDate = DateTime.Parse(row[5]),
                PagesCount = int.Parse(row[6])
            });

        var manwhaChapters = ReadCsvFile(
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

        var animeTags = ReadCsvFile(Path.Combine(Constants.BaseCsvFilesPath, Constants.AnimeTagCsvFilePath),
            row => new AnimeTag
            {
                AnimeKey = int.Parse(row[0]),
                TagKey = int.Parse(row[1]),
                CreatedDate = DateTime.Parse(row[2]),
                UpdatedDate = DateTime.Parse(row[3])
            });

        var mangaTags = ReadCsvFile(Path.Combine(Constants.BaseCsvFilesPath, Constants.MangaTagCsvFilePath),
            row => new MangaTag
            {
                MangaKey = int.Parse(row[0]),
                TagKey = int.Parse(row[1]),
                CreatedDate = DateTime.Parse(row[2]),
                UpdatedDate = DateTime.Parse(row[3])
            });

        var manwhaTags = ReadCsvFile(Path.Combine(Constants.BaseCsvFilesPath, Constants.ManwhaTagCsvFilePath),
            row => new ManwhaTag
            {
                ManwhaKey = int.Parse(row[0]),
                TagKey = int.Parse(row[1]),
                CreatedDate = DateTime.Parse(row[2]),
                UpdatedDate = DateTime.Parse(row[3])
            });

        var animeBrands = ReadCsvFile(Path.Combine(Constants.BaseCsvFilesPath, Constants.AnimeBrandCsvFilePath),
            row => new AnimeBrand
            {
                AnimeKey = int.Parse(row[0]),
                BrandKey = int.Parse(row[1]),
                CreatedDate = DateTime.Parse(row[2]),
                UpdatedDate = DateTime.Parse(row[3])
            });

        var mangaBrands = ReadCsvFile(Path.Combine(Constants.BaseCsvFilesPath, Constants.MangaBrandCsvFilePath),
            row => new MangaBrand
            {
                MangaKey = int.Parse(row[0]),
                BrandKey = int.Parse(row[1]),
                CreatedDate = DateTime.Parse(row[2]),
                UpdatedDate = DateTime.Parse(row[3])
            });

        var manwhaBrands = ReadCsvFile(
            Path.Combine(Constants.BaseCsvFilesPath, Constants.ManwhaBrandCsvFilePath), row => new ManwhaBrand
            {
                ManwhaKey = int.Parse(row[0]),
                BrandKey = int.Parse(row[1]),
                CreatedDate = DateTime.Parse(row[2]),
                UpdatedDate = DateTime.Parse(row[3])
            });

        var mangaAuthors = ReadCsvFile(
            Path.Combine(Constants.BaseCsvFilesPath, Constants.MangaAuthorCsvFilePath), row => new MangaAuthor
            {
                MangaKey = int.Parse(row[0]),
                AuthorKey = int.Parse(row[1]),
                CreatedDate = DateTime.Parse(row[2]),
                UpdatedDate = DateTime.Parse(row[3])
            });

        var manwhaAuthors = ReadCsvFile(
            Path.Combine(Constants.BaseCsvFilesPath, Constants.ManwhaAuthorCsvFilePath), row => new ManwhaAuthor
            {
                ManwhaKey = int.Parse(row[0]),
                AuthorKey = int.Parse(row[1]),
                CreatedDate = DateTime.Parse(row[2]),
                UpdatedDate = DateTime.Parse(row[3])
            });

        var mangaArtists = ReadCsvFile(
            Path.Combine(Constants.BaseCsvFilesPath, Constants.MangaArtistCsvFilePath), row => new MangaArtist
            {
                MangaKey = int.Parse(row[0]),
                ArtistKey = int.Parse(row[1]),
                CreatedDate = DateTime.Parse(row[2]),
                UpdatedDate = DateTime.Parse(row[3])
            });

        var manwhaArtists = ReadCsvFile(
            Path.Combine(Constants.BaseCsvFilesPath, Constants.ManwhaArtistCsvFilePath), row => new ManwhaArtist
            {
                ManwhaKey = int.Parse(row[0]),
                ArtistKey = int.Parse(row[1]),
                CreatedDate = DateTime.Parse(row[2]),
                UpdatedDate = DateTime.Parse(row[3])
            });

        try
        {
            _dbContext.Database.BeginTransaction();

            _dbContext.Anime.AddRange(animes);
            _dbContext.Manga.AddRange(mangas);
            _dbContext.Manwha.AddRange(manwhas);
            _dbContext.Tag.AddRange(tags);
            _dbContext.Brand.AddRange(brands);
            _dbContext.Author.AddRange(authors);
            _dbContext.Artist.AddRange(artists);
            _dbContext.SaveChanges();

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
            _dbContext.SaveChanges();

            _dbContext.Database.CommitTransaction();
        }
        catch (Exception e)
        {
            _dbContext.Database.RollbackTransaction();
            throw;
        }
    }
}

public interface ISeedsMigrator
{
    void Migrate();
}