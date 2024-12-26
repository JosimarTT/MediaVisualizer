using MediaVisualizer.DataAccess.Entities.Manga;
using Microsoft.EntityFrameworkCore;

namespace MediaVisualizer.DataAccess.Configuration;

public static class MangaConfiguration
{
    public static void ConfigureMangaTables(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MangaChapter>()
            .HasMany(x => x.Artists)
            .WithMany(x => x.MangaChapters)
            .UsingEntity<MangaChapterArtist>(
                j => j.ToTable("manga.chapter_artist"));
        modelBuilder.Entity<MangaChapter>()
            .HasMany(x => x.Authors)
            .WithMany(x => x.MangaChapters)
            .UsingEntity<MangaChapterAuthor>(
                j => j.ToTable("manga.chapter_author"));
        modelBuilder.Entity<MangaChapter>()
            .HasMany(x => x.Brands)
            .WithMany(x => x.MangaChapters)
            .UsingEntity<MangaChapterBrand>(
                j => j.ToTable("manga.chapter_brand"));
        modelBuilder.Entity<MangaChapter>()
            .HasMany(x => x.Tags)
            .WithMany(x => x.MangaChapters)
            .UsingEntity<MangaChapterTag>(
                j => j.ToTable("manga.chapter_tag"));
        modelBuilder.Entity<MangaChapterArtist>()
            .ToTable("manga.chapter_artist")
            .HasKey(x => new { x.MangaChapterKey, x.ArtistKey });
        modelBuilder.Entity<MangaChapterAuthor>()
            .ToTable("manga.chapter_author")
            .HasKey(x => new { x.MangaChapterKey, x.AuthorKey });
        modelBuilder.Entity<MangaChapterBrand>()
            .ToTable("manga.chapter_brand")
            .HasKey(x => new { x.MangaChapterKey, x.BrandKey });
        modelBuilder.Entity<MangaChapterTag>()
            .ToTable("manga.chapter_tag")
            .HasKey(x => new { x.MangaChapterKey, x.TagKey });
    }
}