using MediaVisualizer.DataAccess.Entities.Manga;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MediaVisualizer.DataAccess.Configuration;

public class MangaArtistConfig : IEntityTypeConfiguration<MangaArtist>
{
    public void Configure(EntityTypeBuilder<MangaArtist> builder)
    {
        builder.HasKey(e => new { e.MangaId, e.ArtistId });

        builder.HasOne(d => d.Manga)
            .WithMany(p => p.MangaArtists)
            .HasForeignKey(d => d.MangaId);

        builder.HasOne(d => d.Artist)
            .WithMany(p => p.MangaArtists)
            .HasForeignKey(d => d.ArtistId);
    }
}