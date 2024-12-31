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
    public DbSet<Manga> Mangas { get; set; }
    public DbSet<MangaChapter> MangaChapters { get; set; }
    public DbSet<Manwha> Manwhas { get; set; }
    public DbSet<ManwhaChapter> ManwhaChapters { get; set; }
    public DbSet<Artist> Artists { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Tag> Tags { get; set; }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var addedEntities = ChangeTracker.Entries().Where(x => x.State == EntityState.Added).ToList();

        addedEntities.ForEach(x => { x.Property(nameof(AuditEntity.CreatedDate)).CurrentValue = DateTime.Now; });

        var editedEntities = ChangeTracker.Entries().Where(x => x.State == EntityState.Modified).ToList();

        editedEntities.ForEach(x => { x.Property(nameof(AuditEntity.UpdatedDate)).CurrentValue = DateTime.Now; });

        return base.SaveChangesAsync(cancellationToken);
    }
}