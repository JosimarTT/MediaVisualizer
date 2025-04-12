using MediaVisualizer.DataAccess.Entities.Manwha;
using MediaVisualizer.Shared;
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
            Logo = Path.Combine(StringConstants.ManwhaCollectionPath, manwha.Folder, manwha.Logo),
            ChapterNumber = manwha.ChapterNumber,
            PagesCount = manwha.PagesCount,
            PageExtension = manwha.PageExtension,
            Tags = manwha.ManwhaTags.Select(x => x.Tag).ToList().ToListDto(),
            Artists = manwha.ManwhaArtists.Select(x => x.Artist).ToList().ToListDto(),
            BasePath = Path.Combine(StringConstants.ManwhaCollectionPath, manwha.Folder)
        };
    }

    public static IEnumerable<ManwhaDto> ToListDto(this ICollection<Manwha> manwhas)
    {
        if (manwhas == null || manwhas.Count == 0) return [];

        return manwhas.Select(x => x.ToDto());
    }
}