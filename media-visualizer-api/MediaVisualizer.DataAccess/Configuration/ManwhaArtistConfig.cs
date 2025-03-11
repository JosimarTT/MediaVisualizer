using MediaVisualizer.DataAccess.Entities.Manwha;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MediaVisualizer.DataAccess.Configuration;

public class ManwhaArtistConfig : IEntityTypeConfiguration<ManwhaArtist>
{
    public void Configure(EntityTypeBuilder<ManwhaArtist> builder)
    {
        builder.HasKey(e => new { e.ManwhaId, e.ArtistId });

        builder.HasOne(d => d.Manwha)
            .WithMany(p => p.ManwhaArtists)
            .HasForeignKey(d => d.ManwhaId);

        builder.HasOne(d => d.Artist)
            .WithMany(p => p.ManwhaArtists)
            .HasForeignKey(d => d.ArtistId);
    }
}