using MediaVisualizer.DataAccess.Entities.Manwha;
using MediaVisualizer.Shared.Dtos;

namespace MediaVisualizer.Services.Converters;

public static class ManwhaConverter
{
    public static ManwhaDto ToDto(this Manwha manwha)
    {
        if (manwha == null) return null;

        return new ManwhaDto
        {
            ManwhaId = manwha.ManwhaId,
            Folder = manwha.Folder,
            Title = manwha.Title,
            ManwhaChapters = manwha.ManwhaChapters.ToListDto(),
            Brands = manwha.Brands.ToListDto(),
            Tags = manwha.Tags.ToListDto(),
            Artists = manwha.Artists.ToListDto(),
            Authors = manwha.Authors.ToListDto()
        };
    }

    public static ICollection<ManwhaDto> ToListDto(this ICollection<Manwha> manwhas)
    {
        if (manwhas == null || manwhas.Count == 0) return [];

        return manwhas.Select(x => x.ToDto()).ToList();
    }

    public static ManwhaChapterDto ToDto(this ManwhaChapter chapter)
    {
        if (chapter == null) return null;

        return new ManwhaChapterDto
        {
            ManwhaChapterId = chapter.ManwhaChapterId,
            ManwhaId = chapter.ManwhaId,
            ChapterNumber = chapter.ChapterNumber,
            PagesCount = chapter.PagesCount,
            Logo = chapter.Logo
        };
    }

    public static ICollection<ManwhaChapterDto> ToListDto(this ICollection<ManwhaChapter> chapters)
    {
        if (chapters == null || chapters.Count == 0) return [];

        return chapters.Select(x => x.ToDto()).ToList();
    }
}