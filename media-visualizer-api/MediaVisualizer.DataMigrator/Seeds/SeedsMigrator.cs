using System.Text;
using ClosedXML.Excel;
using MediaVisualizer.DataAccess;
using MediaVisualizer.DataAccess.Entities.Anime;
using MediaVisualizer.DataAccess.Entities.Manga;
using MediaVisualizer.DataAccess.Entities.Manwha;
using MediaVisualizer.DataAccess.Entities.Shared;
using MediaVisualizer.Shared;
using Microsoft.EntityFrameworkCore;

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
                    MangaId = int.Parse(row[1]),
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

        var animeTagsTask = ReadCsvFile(Path.Combine(Constants.BaseCsvFilesPath, Constants.AnimeTagCsvFilePath), row =>
            new
            {
                AnimeId = int.Parse(row[0]),
                TagId = int.Parse(row[1]),
                CreatedDate = DateTime.Parse(row[2]),
                UpdatedDate = DateTime.Parse(row[3])
            });

        var mangaTagsTask = ReadCsvFile(Path.Combine(Constants.BaseCsvFilesPath, Constants.MangaTagCsvFilePath), row =>
            new
            {
                MangaId = int.Parse(row[0]),
                TagId = int.Parse(row[1]),
                CreatedDate = DateTime.Parse(row[2]),
                UpdatedDate = DateTime.Parse(row[3])
            });

        var manwhaTagsTask = ReadCsvFile(Path.Combine(Constants.BaseCsvFilesPath, Constants.ManwhaTagCsvFilePath),
            row =>
                new
                {
                    ManwhaId = int.Parse(row[0]),
                    TagId = int.Parse(row[1]),
                    CreatedDate = DateTime.Parse(row[2]),
                    UpdatedDate = DateTime.Parse(row[3])
                });

        var animeBrandsTask = ReadCsvFile(Path.Combine(Constants.BaseCsvFilesPath, Constants.AnimeBrandCsvFilePath),
            row =>
                new
                {
                    AnimeId = int.Parse(row[0]),
                    BrandKey = int.Parse(row[1]),
                    CreatedDate = DateTime.Parse(row[2]),
                    UpdatedDate = DateTime.Parse(row[3])
                });

        var mangaBrandsTask = ReadCsvFile(Path.Combine(Constants.BaseCsvFilesPath, Constants.MangaBrandCsvFilePath),
            row =>
                new
                {
                    MangaId = int.Parse(row[0]),
                    BrandKey = int.Parse(row[1]),
                    CreatedDate = DateTime.Parse(row[2]),
                    UpdatedDate = DateTime.Parse(row[3])
                });

        var manwhaBrandsTask = ReadCsvFile(Path.Combine(Constants.BaseCsvFilesPath, Constants.ManwhaBrandCsvFilePath),
            row =>
                new
                {
                    ManwhaId = int.Parse(row[0]),
                    BrandKey = int.Parse(row[1]),
                    CreatedDate = DateTime.Parse(row[2]),
                    UpdatedDate = DateTime.Parse(row[3])
                });

        var mangaAuthorsTask = ReadCsvFile(Path.Combine(Constants.BaseCsvFilesPath, Constants.MangaAuthorCsvFilePath),
            row =>
                new
                {
                    MangaId = int.Parse(row[0]),
                    AuthorKey = int.Parse(row[1]),
                    CreatedDate = DateTime.Parse(row[2]),
                    UpdatedDate = DateTime.Parse(row[3])
                });

        var manwhaAuthorsTask = ReadCsvFile(Path.Combine(Constants.BaseCsvFilesPath, Constants.ManwhaAuthorCsvFilePath),
            row =>
                new
                {
                    ManwhaId = int.Parse(row[0]),
                    AuthorKey = int.Parse(row[1]),
                    CreatedDate = DateTime.Parse(row[2]),
                    UpdatedDate = DateTime.Parse(row[3])
                });

        var mangaArtistsTask = ReadCsvFile(Path.Combine(Constants.BaseCsvFilesPath, Constants.MangaArtistCsvFilePath),
            row =>
                new
                {
                    MangaId = int.Parse(row[0]),
                    ArtistId = int.Parse(row[1]),
                    CreatedDate = DateTime.Parse(row[2]),
                    UpdatedDate = DateTime.Parse(row[3])
                });

        var manwhaArtistsTask = ReadCsvFile(Path.Combine(Constants.BaseCsvFilesPath, Constants.ManwhaArtistCsvFilePath),
            row =>
                new
                {
                    ManwhaId = int.Parse(row[0]),
                    ArtistId = int.Parse(row[1]),
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

            foreach (var animeTag in animeTags)
            {
                var anime = animes.FirstOrDefault(a => a.AnimeId == animeTag.AnimeId);
                var tag = tags.FirstOrDefault(t => t.TagId == animeTag.TagId);

                if (anime != null && tag != null)
                {
                    anime.Tags.Add(tag);
                }
            }

            foreach (var mangaTag in mangaTags)
            {
                var manga = mangas.FirstOrDefault(a => a.MangaId == mangaTag.MangaId);
                var tag = tags.FirstOrDefault(t => t.TagId == mangaTag.TagId);

                if (manga != null && tag != null)
                {
                    manga.Tags.Add(tag);
                }
            }

            foreach (var manwhaTag in manwhaTags)
            {
                var manwha = manwhas.FirstOrDefault(a => a.ManwhaId == manwhaTag.ManwhaId);
                var tag = tags.FirstOrDefault(t => t.TagId == manwhaTag.TagId);

                if (manwha != null && tag != null)
                {
                    manwha.Tags.Add(tag);
                }
            }

            foreach (var animeBrand in animeBrands)
            {
                var anime = animes.FirstOrDefault(a => a.AnimeId == animeBrand.AnimeId);
                var brand = brands.FirstOrDefault(b => b.BrandId == animeBrand.BrandKey);

                if (anime != null && brand != null)
                {
                    anime.Brands.Add(brand);
                }
            }

            foreach (var mangaBrand in mangaBrands)
            {
                var manga = mangas.FirstOrDefault(a => a.MangaId == mangaBrand.MangaId);
                var brand = brands.FirstOrDefault(b => b.BrandId == mangaBrand.BrandKey);

                if (manga != null && brand != null)
                {
                    manga.Brands.Add(brand);
                }
            }

            foreach (var manwhaBrand in manwhaBrands)
            {
                var manwha = manwhas.FirstOrDefault(a => a.ManwhaId == manwhaBrand.ManwhaId);
                var brand = brands.FirstOrDefault(b => b.BrandId == manwhaBrand.BrandKey);

                if (manwha != null && brand != null)
                {
                    manwha.Brands.Add(brand);
                }
            }

            foreach (var mangaAuthor in mangaAuthors)
            {
                var manga = mangas.FirstOrDefault(a => a.MangaId == mangaAuthor.MangaId);
                var author = authors.FirstOrDefault(b => b.AuthorId == mangaAuthor.AuthorKey);

                if (manga != null && author != null)
                {
                    manga.Authors.Add(author);
                }
            }

            foreach (var manwhaAuthor in manwhaAuthors)
            {
                var manwha = manwhas.FirstOrDefault(a => a.ManwhaId == manwhaAuthor.ManwhaId);
                var author = authors.FirstOrDefault(b => b.AuthorId == manwhaAuthor.AuthorKey);

                if (manwha != null && author != null)
                {
                    manwha.Authors.Add(author);
                }
            }

            foreach (var mangaArtist in mangaArtists)
            {
                var manga = mangas.FirstOrDefault(a => a.MangaId == mangaArtist.MangaId);
                var artist = artists.FirstOrDefault(b => b.ArtistId == mangaArtist.ArtistId);

                if (manga != null && artist != null)
                {
                    manga.Artists.Add(artist);
                }
            }

            foreach (var manwhaArtist in manwhaArtists)
            {
                var manwha = manwhas.FirstOrDefault(a => a.ManwhaId == manwhaArtist.ManwhaId);
                var artist = artists.FirstOrDefault(b => b.ArtistId == manwhaArtist.ArtistId);

                if (manwha != null && artist != null)
                {
                    manwha.Artists.Add(artist);
                }
            }


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