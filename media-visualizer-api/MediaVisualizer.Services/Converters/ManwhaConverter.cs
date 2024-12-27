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
            ManwhaKey = manwha.ManwhaKey,
            Folder = manwha.Folder,
            Title = manwha.Title,
            ManwhaChapters = manwha.ManwhaChapters.ToListDto(),
            Brands = manwha.Brands.ToListDto(),
            Tags = manwha.Tags.ToListDto()
        };
    }

    public static ICollection<ManwhaDto> ToListDto(this ICollection<Manwha> manwhas)
    {
        if (manwhas == null || manwhas.Count == 0) return [];

        return manwhas.Select(x => x.ToDto()).ToList();
    }

    public static ManwhaChapterDto ConvertToManwhaChapterDto(this ManwhaChapter chapter)
    {
        if (chapter == null) return null;

        return new ManwhaChapterDto
        {
            ManwhaChapterKey = chapter.ManwhaChapterKey,
            ManwhaKey = chapter.ManwhaKey,
            ChapterNumber = chapter.ChapterNumber,
            PagesCount = chapter.PagesCount,
            Logo = chapter.Logo
        };
    }

    public static ICollection<ManwhaChapterDto> ToListDto(this ICollection<ManwhaChapter> chapters)
    {
        if (chapters == null || chapters.Count == 0) return [];

        return chapters.Select(x => x.ConvertToManwhaChapterDto()).ToList();
    }
}