using MediaVisualizer.DataAccess.Entities.Anime;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MediaVisualizer.DataAccess.Configuration;

public class AnimeTagConfig : IEntityTypeConfiguration<AnimeTag>
{
    public void Configure(EntityTypeBuilder<AnimeTag> builder)
    {
        builder.HasKey(x => new { x.AnimeId, x.TagId });

        builder.HasOne(x => x.Anime)
            .WithMany(x => x.AnimeTags)
            .HasForeignKey(x => x.AnimeId);

        builder.HasOne(x => x.Tag)
            .WithMany(x => x.AnimeTags)
            .HasForeignKey(x => x.TagId);
    }
}