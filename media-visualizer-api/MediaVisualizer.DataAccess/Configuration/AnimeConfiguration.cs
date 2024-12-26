using MediaVisualizer.DataAccess.Entities.Anime;
using Microsoft.EntityFrameworkCore;

namespace MediaVisualizer.DataAccess.Configuration;

public static class AnimeConfiguration
{
    public static void ConfigureAnimeTables(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Anime>()
            .HasMany(x => x.Brands)
            .WithMany(x => x.Animes)
            .UsingEntity<AnimeBrand>();

        modelBuilder.Entity<Anime>()
            .HasMany(x => x.Tags)
            .WithMany(x => x.Animes)
            .UsingEntity<AnimeTag>();

        modelBuilder.Entity<AnimeBrand>()
            .HasKey(x => new {x.AnimeKey, x.BrandKey });

        modelBuilder.Entity<AnimeTag>()
            .HasKey(x => new { x.AnimeKey, x.TagKey });
    }
}