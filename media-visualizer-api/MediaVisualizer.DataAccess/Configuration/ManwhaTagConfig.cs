using MediaVisualizer.DataAccess.Entities.Manwha;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MediaVisualizer.DataAccess.Configuration;

public class ManwhaTagConfig : IEntityTypeConfiguration<ManwhaTag>
{
    public void Configure(EntityTypeBuilder<ManwhaTag> builder)
    {
        builder.HasKey(e => new { e.ManwhaId, e.TagId });

        builder.HasOne(d => d.Manwha)
            .WithMany(p => p.ManwhaTags)
            .HasForeignKey(d => d.ManwhaId);

        builder.HasOne(d => d.Tag)
            .WithMany(p => p.ManwhaTags)
            .HasForeignKey(d => d.TagId);
    }
}