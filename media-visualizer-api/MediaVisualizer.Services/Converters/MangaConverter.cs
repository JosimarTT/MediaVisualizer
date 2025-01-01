using MediaVisualizer.DataAccess.Entities.Manga;
using MediaVisualizer.Shared.Dtos;

namespace MediaVisualizer.Services.Converters;

public static class MangaConverter
{
    public static MangaDto ToDto(this Manga manga)
    {
        if (manga == null) return null;

        return new MangaDto
        {
            MangaId = manga.MangaId,
            Folder = manga.Folder,
            Title = manga.Title,
            Chapters = manga.MangaChapters.ToListDto(),
            Brands = manga.Brands.ToListDto(),
            Tags = manga.Tags.ToListDto(),
            Artists = manga.Artists.ToListDto(),
            Authors = manga.Authors.ToListDto(),
        };
    }

    public static ICollection<MangaDto> ToListDto(this ICollection<Manga> mangas)
    {
        if (mangas == null || mangas.Count == 0) return new List<MangaDto>();

        return mangas.Select(x => x.ToDto()).ToList();
    }

    public static MangaChapterDto ConvertToMangaChapterDto(this MangaChapter chapter)
    {
        if (chapter == null) return null;

        return new MangaChapterDto
        {
            MangaChapterId = chapter.MangaChapterId,
            MangaKey = chapter.MangaId,
            ChapterNumber = chapter.ChapterNumber,
            PagesCount = chapter.PagesCount,
            Logo = chapter.Logo
        };
    }

    public static ICollection<MangaChapterDto> ToListDto(this ICollection<MangaChapter> chapters)
    {
        if (chapters == null || chapters.Count == 0) return new List<MangaChapterDto>();

        return chapters.Select(x => x.ConvertToMangaChapterDto()).ToList();
    }
}