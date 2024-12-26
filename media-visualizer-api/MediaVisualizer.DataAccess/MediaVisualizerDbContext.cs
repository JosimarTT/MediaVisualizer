using MediaVisualizer.DataAccess.Configuration;
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

    public DbSet<Anime> Anime { get; set; }
    public DbSet<AnimeChapter> AnimeChapter { get; set; }
    public DbSet<AnimeBrand> AnimeBrand { get; set; }
    public DbSet<AnimeTag> AnimeTag { get; set; }

    public DbSet<Manga> Manga { get; set; }
    public DbSet<MangaChapter> MangaChapter { get; set; }
    public DbSet<MangaArtist> MangaArtist { get; set; }
    public DbSet<MangaAuthor> MangaAuthor { get; set; }
    public DbSet<MangaBrand> MangaBrand { get; set; }
    public DbSet<MangaTag> MangaTag { get; set; }

    public DbSet<Manwha> Manwha { get; set; }
    public DbSet<ManwhaChapter> ManwhaChapter { get; set; }
    public DbSet<ManwhaArtist> ManwhaArtist { get; set; }
    public DbSet<ManwhaAuthor> ManwhaAuthor { get; set; }
    public DbSet<ManwhaBrand> ManwhaBrand { get; set; }
    public DbSet<ManwhaTag> ManwhaTag { get; set; }

    public DbSet<Artist> Artist { get; set; }
    public DbSet<Author> Author { get; set; }
    public DbSet<Brand> Brand { get; set; }
    public DbSet<Tag> Tag { get; set; }

protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.ConfigureAnimeTables();
    modelBuilder.ConfigureMangaTables();
    modelBuilder.ConfigureManwhaTables();

    base.OnModelCreating(modelBuilder);
}


}