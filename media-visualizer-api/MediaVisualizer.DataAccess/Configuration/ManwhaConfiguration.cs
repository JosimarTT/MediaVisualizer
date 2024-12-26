using MediaVisualizer.DataAccess.Entities.Manwha;
using Microsoft.EntityFrameworkCore;

namespace MediaVisualizer.DataAccess.Configuration;

public static class ManwhaConfiguration
{
    public static void ConfigureManwhaTables(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ManwhaChapter>()
            .HasMany(x => x.Artists)
            .WithMany(x => x.ManwhaChapters)
            .UsingEntity<ManwhaChapterArtist>(
                j => j.ToTable("manwha.chapter_artist"));
        modelBuilder.Entity<ManwhaChapter>()
            .HasMany(x => x.Authors)
            .WithMany(x => x.ManwhaChapters)
            .UsingEntity<ManwhaChapterAuthor>(
                j => j.ToTable("manwha.chapter_author"));
        modelBuilder.Entity<ManwhaChapter>()
            .HasMany(x => x.Brands)
            .WithMany(x => x.ManwhaChapters)
            .UsingEntity<ManwhaChapterBrand>(
                j => j.ToTable("manwha.chapter_brand"));
        modelBuilder.Entity<ManwhaChapter>()
            .HasMany(x => x.Tags)
            .WithMany(x => x.ManwhaChapters)
            .UsingEntity<ManwhaChapterTag>(
                j => j.ToTable("manwha.chapter_tag"));
        modelBuilder.Entity<ManwhaChapterArtist>()
            .ToTable("manwha.chapter_artist")
            .HasKey(x => new { x.ManwhaChapterKey, x.ArtistKey });
        modelBuilder.Entity<ManwhaChapterAuthor>()
            .ToTable("manwha.chapter_author")
            .HasKey(x => new { x.ManwhaChapterKey, x.AuthorKey });
        modelBuilder.Entity<ManwhaChapterBrand>()
            .ToTable("manwha.chapter_brand")
            .HasKey(x => new { x.ManwhaChapterKey, x.BrandKey });
        modelBuilder.Entity<ManwhaChapterTag>()
            .ToTable("manwha.chapter_tag")
            .HasKey(x => new { x.ManwhaChapterKey, x.TagKey });
    }

}