using MediaVisualizer.DataAccess.Entities.Anime;
using MediaVisualizer.Shared.Dtos;

namespace MediaVisualizer.Shared.Converters;

public static class AnimeToAnimeDto
{
    public static AnimeDto ConvertToAnimeDto(this Anime anime)
    {
        if (anime == null) return null;

        return new AnimeDto
        {
            AnimeKey = anime.AnimeKey,
            Folder = anime.Folder,
            Title = anime.Title,
            Brands = anime.Brands.ConvertToListDto(),
            Tags = anime.Tags.ConvertToListDto()
        };
    }

    public static ICollection<AnimeDto> ConvertToListDto(this ICollection<Anime> animes)
    {
        if (animes == null || animes.Count == 0) return  [];

        return animes.Select(x => x.ConvertToAnimeDto()).ToList();
    }
}