using MediaVisualizer.DataAccess.Entities.Anime;
using MediaVisualizer.Shared.Dtos;

namespace MediaVisualizer.Services.Converters;

public static class AnimeConverter
{
    public static AnimeDto ToDto(this Anime anime)
    {
        if (anime == null) return null;

        return new AnimeDto
        {
            AnimeKey = anime.AnimeId,
            Folder = anime.Folder,
            Title = anime.Title,
            Brands = anime.Brands.ToListDto(),
            Tags = anime.Tags.ToListDto()
        };
    }

    public static ICollection<AnimeDto> ToListDto(this ICollection<Anime> animes)
    {
        if (animes == null || animes.Count == 0) return [];

        return animes.Select(x => x.ToDto()).ToList();
    }
}