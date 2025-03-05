using MediaVisualizer.DataAccess.Entities;
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
    public DbSet<Manga> Mangas { get; set; }
    public DbSet<Manwha> Manwhas { get; set; }
    public DbSet<ManwhaChapter> ManwhaChapters { get; set; }
    public DbSet<Artist> Artists { get; set; }
    public DbSet<Author> Authors { get; set; }
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

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var addedEntities = ChangeTracker.Entries()
            .Where(x => x.State == EntityState.Added && x.Entity is AuditEntity)
            .ToList();

        addedEntities.ForEach(x => { ((AuditEntity)x.Entity).CreatedDate = DateTime.Now; });

        var editedEntities = ChangeTracker.Entries()
            .Where(x => x.State == EntityState.Modified && x.Entity is AuditEntity)
            .ToList();

        editedEntities.ForEach(x => { ((AuditEntity)x.Entity).UpdatedDate = DateTime.Now; });

        return base.SaveChangesAsync(cancellationToken);
    }
}