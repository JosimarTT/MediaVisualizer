using MediaVisualizer.DataAccess.Entities.Anime;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MediaVisualizer.DataAccess.Configuration;

public class AnimeBrandConfig : IEntityTypeConfiguration<AnimeBrand>
{
    public void Configure(EntityTypeBuilder<AnimeBrand> builder)
    {
        builder.HasKey(x => new { x.AnimeId, x.BrandId });

        builder.HasOne(x => x.Anime)
            .WithMany(x => x.AnimeBrands)
            .HasForeignKey(x => x.AnimeId);

        builder.HasOne(x => x.Brand)
            .WithMany(x => x.AnimeBrands)
            .HasForeignKey(x => x.BrandId);
    }
}