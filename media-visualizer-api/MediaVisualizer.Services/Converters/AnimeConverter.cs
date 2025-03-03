using MediaVisualizer.DataAccess;
using MediaVisualizer.DataAccess.Entities;
using MediaVisualizer.Services.Dtos;
using MediaVisualizer.Shared;
using MediaVisualizer.Shared.Dtos;

namespace MediaVisualizer.Services.Converters;

public static class AnimeConverter
{
    public static AnimeDto ToDto(this Anime anime)
    {
        if (anime == null) return null;

        return new AnimeDto
        {
            AnimeId = anime.AnimeId,
            Folder = anime.Folder,
            Title = anime.Title,
            ChapterNumber = anime.ChapterNumber,
            Logo = anime.Logo,
            Video = anime.Video,
            Brands = anime.Brands.ToListDto(),
            Tags = anime.Tags.ToListDto(),
            BasePath = Path.Combine(Constants.BaseCollectionFolderPath, Constants.AnimeFolderPath, anime.Folder)
        };
    }

    public static ICollection<AnimeDto> ToListDto(this ICollection<Anime> animes)
    {
        if (animes == null || animes.Count == 0) return [];

        return animes.Select(x => x.ToDto()).ToList();
    }
}