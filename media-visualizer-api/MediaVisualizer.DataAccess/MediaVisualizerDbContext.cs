using MediaVisualizer.DataAccess.Entities.Anime;
using MediaVisualizer.DataAccess.Entities.Manga;
using MediaVisualizer.DataAccess.Entities.Manwha;
using MediaVisualizer.DataAccess.Entities.Shared;
using MediaVisualizer.Shared;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace MediaVisualizer.DataAccess;

public class MediaVisualizerDbContext : DbContext
{
    public MediaVisualizerDbContext(DbContextOptions<MediaVisualizerDbContext> options) : base(options)
    {
    }

    public DbSet<Anime> Animes { get; set; }
    public DbSet<AnimeBrand> AnimeBrands { get; set; }
    public DbSet<AnimeTag> AnimeTags { get; set; }
    public DbSet<Manga> Mangas { get; set; }
    public DbSet<MangaArtist> MangaArtists { get; set; }
    public DbSet<MangaTag> MangaTags { get; set; }
    public DbSet<Manwha> Manwhas { get; set; }
    public DbSet<ManwhaArtist> ManwhaArtists { get; set; }
    public DbSet<ManwhaTag> ManwhaTags { get; set; }
    public DbSet<Artist> Artists { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Tag> Tags { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connection = new SqliteConnection($"Data Source={Constants.DbPath}");
        connection.Open();
        using (var command = connection.CreateCommand())
        {
            command.CommandText = "PRAGMA foreign_keys = ON;";
            command.ExecuteNonQuery();
        }

        optionsBuilder.UseSqlite(connection);
    }
}