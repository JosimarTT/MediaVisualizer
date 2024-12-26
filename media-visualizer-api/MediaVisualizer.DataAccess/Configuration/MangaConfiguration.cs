using MediaVisualizer.DataAccess.Entities.Manga;
using Microsoft.EntityFrameworkCore;

namespace MediaVisualizer.DataAccess.Configuration;

public static class MangaConfiguration
{
    public static void ConfigureMangaTables(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Manga>()
            .HasMany(x => x.Artists)
            .WithMany(x => x.Mangas)
            .UsingEntity<MangaArtist>();

        modelBuilder.Entity<Manga>()
            .HasMany(x => x.Authors)
            .WithMany(x => x.Mangas)
            .UsingEntity<MangaAuthor>();

        modelBuilder.Entity<Manga>()
            .HasMany(x => x.Brands)
            .WithMany(x => x.Mangas)
            .UsingEntity<MangaBrand>();

        modelBuilder.Entity<Manga>()
            .HasMany(x => x.Tags)
            .WithMany(x => x.Mangas)
            .UsingEntity<MangaTag>();

        modelBuilder.Entity<MangaArtist>()
            .HasKey(x => new { x.MangaKey, x.ArtistKey });

        modelBuilder.Entity<MangaAuthor>()
            .HasKey(x => new {  x.MangaKey, x.AuthorKey });

        modelBuilder.Entity<MangaBrand>()
            .HasKey(x => new { x.MangaKey, x.BrandKey });

        modelBuilder.Entity<MangaTag>()
            .HasKey(x => new { x.MangaKey, x.TagKey });
    }
}