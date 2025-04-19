using System.Text.Json;
using MediaVisualizer.DataAccess.Entities.Manwha;
using MediaVisualizer.Shared;
using MediaVisualizer.Shared.Dtos;

namespace MediaVisualizer.Services.Converters;

public static class ManwhaConverter
{
    public static ManwhaDto ToDto(this Manwha manwha)
    {
        if (manwha == null) return null;

        var basePath = Path.Combine(StringConstants.ManwhaCollectionPath, manwha.Folder);

        var chapters = !string.IsNullOrWhiteSpace(manwha.Chapters)
            ? JsonSerializer.Deserialize<List<ManwhaChapterDto>>(manwha.Chapters)!
            : [];

        foreach (var chapter in chapters)
            chapter.Logo = !string.IsNullOrWhiteSpace(chapter.Logo)
                ? Path.Combine(basePath, chapter.Logo)
                : string.Empty;

        var logos = !string.IsNullOrWhiteSpace(manwha.Logos)
            ? JsonSerializer.Deserialize<string[]>(manwha.Logos)!
            : [];

        for (var i = 0; i < logos.Length; i++)
            logos[i] = !string.IsNullOrWhiteSpace(logos[i])
                ? Path.Combine(basePath, logos[i])
                : string.Empty;

        return new ManwhaDto
        {
            ManwhaId = manwha.ManwhaId,
            Folder = manwha.Folder,
            Title = manwha.Title,
            Logos = logos,
            Chapters = chapters,
            Tags = manwha.ManwhaTags.Select(x => x.Tag).ToList().ToListDto(),
            Artists = manwha.ManwhaArtists.Select(x => x.Artist).ToList().ToListDto(),
            BasePath = basePath
        };
    }

    public static IEnumerable<ManwhaDto> ToListDto(this ICollection<Manwha> manwhas)
    {
        if (manwhas == null || manwhas.Count == 0) return [];

        return manwhas.Select(x => x.ToDto());
    }
}