using MediaVisualizer.DataAccess.Entities.Manwha;
using Microsoft.EntityFrameworkCore;

namespace MediaVisualizer.DataAccess.Configuration;

public static class ManwhaConfiguration
{
    public static void ConfigureManwhaTables(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Manwha>()
            .HasMany(x => x.Artists)
            .WithMany(x => x.Manwhas)
            .UsingEntity<ManwhaArtist>();

        modelBuilder.Entity<Manwha>()
            .HasMany(x => x.Authors)
            .WithMany(x => x.Manwhas)
            .UsingEntity<ManwhaAuthor>();

        modelBuilder.Entity<Manwha>()
            .HasMany(x => x.Brands)
            .WithMany(x => x.Manwhas)
            .UsingEntity<ManwhaBrand>();

        modelBuilder.Entity<Manwha>()
            .HasMany(x => x.Tags)
            .WithMany(x => x.Manwhas)
            .UsingEntity<ManwhaTag>();

        modelBuilder.Entity<ManwhaArtist>()
            .HasKey(x => new { x.ManwhaKey, x.ArtistKey });

        modelBuilder.Entity<ManwhaAuthor>()
            .HasKey(x => new {  x.ManwhaKey, x.AuthorKey });

        modelBuilder.Entity<ManwhaBrand>()
            .HasKey(x => new {  x.ManwhaKey, x.BrandKey });

        modelBuilder.Entity<ManwhaTag>()
            .HasKey(x => new {  x.ManwhaKey, x.TagKey });
    }
}