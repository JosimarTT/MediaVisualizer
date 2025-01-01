using MediaVisualizer.DataAccess.Entities.Shared;
using MediaVisualizer.Shared.Dtos;

namespace MediaVisualizer.Services.Converters;

public static class ArtistConverter
{
    public static ArtistDto ToDto(this Artist artist)
    {
        if (artist == null) return null;

        return new ArtistDto
        {
            ArtistId = artist.ArtistId,
            Name = artist.Name,
        };
    }

    public static ICollection<ArtistDto> ToListDto(this ICollection<Artist> artists)
    {
        if (artists == null || artists.Count == 0) return new List<ArtistDto>();

        return artists.Select(x => x.ToDto()).ToList();
    }
}