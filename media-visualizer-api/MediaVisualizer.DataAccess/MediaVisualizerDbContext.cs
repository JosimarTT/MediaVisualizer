using MediaVisualizer.DataAccess.Entities;
using MediaVisualizer.DataAccess.Entities.Anime;
using MediaVisualizer.DataAccess.Entities.Manga;
using MediaVisualizer.DataAccess.Entities.Manwha;
using MediaVisualizer.DataAccess.Entities.Shared;
using Microsoft.EntityFrameworkCore;

namespace MediaVisualizer.DataAccess;

public class MediaVisualizerDbContext : DbContext
{
    public MediaVisualizerDbContext(DbContextOptions<MediaVisualizerDbContext> options) : base(options)
    {
    }

    public DbSet<Anime> Animes { get; set; }
    public DbSet<AnimeChapter> AnimeChapters { get; set; }
    public DbSet<AnimeChapterBrand> AnimeChapterBrands { get; set; }
    public DbSet<AnimeChapterTag> AnimeChapterTags { get; set; }

    public DbSet<Manga> Mangas { get; set; }
    public DbSet<MangaChapter> MangaChapters { get; set; }
    public DbSet<MangaChapterArtist> MangaChapterArtists { get; set; }
    public DbSet<MangaChapterAuthor> MangaChapterAuthors { get; set; }
    public DbSet<MangaChapterBrand> MangaChapterBrands { get; set; }
    public DbSet<MangaChapterTag> MangaChapterTags { get; set; }

    public DbSet<Manwha> Manwhas { get; set; }
    public DbSet<ManwhaChapter> ManwhaChapters { get; set; }
    public DbSet<ManwhaChapterArtist> ManwhaChapterArtists { get; set; }
    public DbSet<ManwhaChapterAuthor> ManwhaChapterAuthors { get; set; }
    public DbSet<ManwhaChapterBrand> ManwhaChapterBrands { get; set; }
    public DbSet<ManwhaChapterTag> ManwhaChapterTags { get; set; }

    public DbSet<Artist> Artists { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Tag> Tags { get; set; }
}