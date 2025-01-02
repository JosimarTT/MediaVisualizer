using MediaVisualizer.DataAccess.Entities.Anime;
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
            Chapters = anime.AnimeChapters.ToListDto(),
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

    public static AnimeChapterDto ToDto(this AnimeChapter chapter)
    {
        if (chapter == null) return null;

        return new AnimeChapterDto
        {
            AnimeChapterId = chapter.AnimeChapterId,
            AnimeId = chapter.AnimeId,
            ChapterNumber = chapter.ChapterNumber,
            Logo = chapter.Logo,
            Video = chapter.Video
        };
    }

    public static ICollection<AnimeChapterDto> ToListDto(this ICollection<AnimeChapter> chapters)
    {
        if (chapters == null || chapters.Count == 0) return [];

        return chapters.Select(x => x.ToDto()).ToList();
    }
}