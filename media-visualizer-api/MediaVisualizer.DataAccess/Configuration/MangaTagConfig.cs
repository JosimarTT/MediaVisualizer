using MediaVisualizer.DataAccess.Entities.Manga;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MediaVisualizer.DataAccess.Configuration;

public class MangaTagConfig : IEntityTypeConfiguration<MangaTag>
{
    public void Configure(EntityTypeBuilder<MangaTag> builder)
    {
        builder.HasKey(e => new { e.MangaId, e.TagId });

        builder.HasOne(d => d.Manga)
            .WithMany(p => p.MangaTags)
            .HasForeignKey(d => d.MangaId);

        builder.HasOne(d => d.Tag)
            .WithMany(p => p.MangaTags)
            .HasForeignKey(d => d.TagId);
    }
}