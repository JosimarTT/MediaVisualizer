using ClosedXML.Excel;
using MediaVisualizer.DataAccess;
using MediaVisualizer.DataAccess.Entities.Anime;
using MediaVisualizer.DataAccess.Entities.Manga;
using MediaVisualizer.DataAccess.Entities.Manwha;
using MediaVisualizer.DataAccess.Entities.Shared;

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
        var basePath = @"E:\media-visualizer\media-visualizer-api\MediaVisualizer.DataMigrator\Seeds\CsvFiles";

        var manwhas = ReadCsvFile(Path.Combine(basePath, "Anime.csv"), row => new Manwha
        {
            Folder = row[0],
            Title = row[1],
            CreatedDate = DateTime.Parse(row[2]),
            UpdatedDate = DateTime.Parse(row[3])
        });

        var animes = ReadCsvFile(Path.Combine(basePath, "Anime.csv"), row => new Anime
        {
            Folder = row[0],
            Title = row[1],
            CreatedDate = DateTime.Parse(row[2]),
            UpdatedDate = DateTime.Parse(row[3])
        });

        var mangas = ReadCsvFile(Path.Combine(basePath, "Manga.csv"), row => new Manga
        {
            Folder = row[0],
            Title = row[1],
            CreatedDate = DateTime.Parse(row[2]),
            UpdatedDate = DateTime.Parse(row[3])
        });

        var tags = ReadCsvFile(Path.Combine(basePath, "Tag.csv"), row => new Tag
        {
            Name = row[0],
            CreatedDate = DateTime.Parse(row[1]),
            UpdatedDate = DateTime.Parse(row[2])
        });

        var brands = ReadCsvFile(Path.Combine(basePath, "Brand.csv"), row => new Brand
        {
            Name = row[0],
            CreatedDate = DateTime.Parse(row[1]),
            UpdatedDate = DateTime.Parse(row[2])
        });

        var authors = ReadCsvFile(Path.Combine(basePath, "Author.csv"), row => new Author
        {
            Name = row[0],
            CreatedDate = DateTime.Parse(row[1]),
            UpdatedDate = DateTime.Parse(row[2])
        });

        var artists = ReadCsvFile(Path.Combine(basePath, "Artist.csv"), row => new Artist
        {
            Name = row[0],
            CreatedDate = DateTime.Parse(row[1]),
            UpdatedDate = DateTime.Parse(row[2])
        });

        var animeChapters = ReadCsvFile(Path.Combine(basePath, "AnimeChapter.csv"), row => new AnimeChapter
        {
            AnimeChapterKey = int.Parse(row[0]),
            AnimeKey = int.Parse(row[1]),
            ChapterNumber = int.Parse(row[2]),
            Logo = row[3],
            CreatedDate = DateTime.Parse(row[4]),
            UpdatedDate = DateTime.Parse(row[5])
        });

        var mangaChapters = ReadCsvFile(Path.Combine(basePath, "MangaChapter.csv"), row => new MangaChapter
        {
            MangaChapterKey = int.Parse(row[0]),
            MangaKey = int.Parse(row[1]),
            ChapterNumber = int.Parse(row[2]),
            Logo = row[3],
            CreatedDate = DateTime.Parse(row[4]),
            UpdatedDate = DateTime.Parse(row[5]),
            PagesCount = int.Parse(row[6])
        });

        var manwhaChapters = ReadCsvFile(Path.Combine(basePath, "ManwhaChapter.csv"), row => new ManwhaChapter
        {
            ManwhaChapterKey = int.Parse(row[0]),
            ManwhaKey = int.Parse(row[1]),
            ChapterNumber = int.Parse(row[2]),
            Logo = row[3],
            CreatedDate = DateTime.Parse(row[4]),
            UpdatedDate = DateTime.Parse(row[5]),
            PagesCount = int.Parse(row[6])
        });

        var animeTags = ReadCsvFile(Path.Combine(basePath, "AnimeTag.csv"), row => new AnimeTag
        {
            AnimeKey = int.Parse(row[0]),
            TagKey = int.Parse(row[1]),
            CreatedDate = DateTime.Parse(row[2]),
            UpdatedDate = DateTime.Parse(row[3])
        });

        var mangaTags = ReadCsvFile(Path.Combine(basePath, "MangaTag.csv"), row => new MangaTag
        {
            MangaKey = int.Parse(row[0]),
            TagKey = int.Parse(row[1]),
            CreatedDate = DateTime.Parse(row[2]),
            UpdatedDate = DateTime.Parse(row[3])
        });

        var manwhaTags = ReadCsvFile(Path.Combine(basePath, "ManwhaTag.csv"), row => new ManwhaTag
        {
            ManwhaKey = int.Parse(row[0]),
            TagKey = int.Parse(row[1]),
            CreatedDate = DateTime.Parse(row[2]),
            UpdatedDate = DateTime.Parse(row[3])
        });

        var animeBrands = ReadCsvFile(Path.Combine(basePath, "AnimeBrand.csv"), row => new AnimeBrand
        {
            AnimeKey = int.Parse(row[0]),
            BrandKey = int.Parse(row[1]),
            CreatedDate = DateTime.Parse(row[2]),
            UpdatedDate = DateTime.Parse(row[3])
        });

        var mangaBrands = ReadCsvFile(Path.Combine(basePath, "MangaBrand.csv"), row => new MangaBrand
        {
            MangaKey = int.Parse(row[0]),
            BrandKey = int.Parse(row[1]),
            CreatedDate = DateTime.Parse(row[2]),
            UpdatedDate = DateTime.Parse(row[3])
        });

        var manwhaBrands = ReadCsvFile(Path.Combine(basePath, "ManwhaBrand.csv"), row => new ManwhaBrand
        {
            ManwhaKey = int.Parse(row[0]),
            BrandKey = int.Parse(row[1]),
            CreatedDate = DateTime.Parse(row[2]),
            UpdatedDate = DateTime.Parse(row[3])
        });

        var mangaAuthors = ReadCsvFile(Path.Combine(basePath, "MangaAuthor.csv"), row => new MangaAuthor
        {
            MangaKey = int.Parse(row[0]),
            AuthorKey = int.Parse(row[1]),
            CreatedDate = DateTime.Parse(row[2]),
            UpdatedDate = DateTime.Parse(row[3])
        });

        var manwhaAuthors = ReadCsvFile(Path.Combine(basePath, "ManwhaAuthor.csv"), row => new ManwhaAuthor
        {
            ManwhaKey = int.Parse(row[0]),
            AuthorKey = int.Parse(row[1]),
            CreatedDate = DateTime.Parse(row[2]),
            UpdatedDate = DateTime.Parse(row[3])
        });

        var mangaArtists = ReadCsvFile(Path.Combine(basePath, "MangaArtist.csv"), row => new MangaArtist
        {
            MangaKey = int.Parse(row[0]),
            ArtistKey = int.Parse(row[1]),
            CreatedDate = DateTime.Parse(row[2]),
            UpdatedDate = DateTime.Parse(row[3])
        });

        var manwhaArtists = ReadCsvFile(Path.Combine(basePath, "ManwhaArtist.csv"), row => new ManwhaArtist
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