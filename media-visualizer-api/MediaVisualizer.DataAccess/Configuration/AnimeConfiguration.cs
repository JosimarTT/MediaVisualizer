using MediaVisualizer.DataAccess.Entities.Anime;
using Microsoft.EntityFrameworkCore;

namespace MediaVisualizer.DataAccess.Configuration;

public static class AnimeConfiguration
{
    public static void ConfigureAnimeTables(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AnimeChapter>()
            .HasMany(x => x.Brands)
            .WithMany(x => x.AnimeChapters)
            .UsingEntity<AnimeChapterBrand>(
                j => j.ToTable("anime.chapter_brand"));
        modelBuilder.Entity<AnimeChapter>()
            .HasMany(x => x.Tags)
            .WithMany(x => x.AnimeChapters)
            .UsingEntity<AnimeChapterTag>(
                j => j.ToTable("anime.chapter_tag"));
        modelBuilder.Entity<AnimeChapterBrand>()
            .ToTable("anime.chapter_brand")
            .HasKey(x => new { x.AnimeChapterKey, x.BrandKey });
        modelBuilder.Entity<AnimeChapterTag>()
            .ToTable("anime.chapter_tag")
            .HasKey(x => new { x.AnimeChapterKey, x.TagKey });
    }
}