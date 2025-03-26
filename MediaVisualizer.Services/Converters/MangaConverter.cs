using MediaVisualizer.DataAccess.Entities.Manga;
using MediaVisualizer.Services.Dtos;
using MediaVisualizer.Shared;
using MediaVisualizer.Shared.ExtensionMethods;

namespace MediaVisualizer.Services.Converters;

public static class MangaConverter
{
    public static async Task<MangaDto> ToDto(this Manga manga, double? percentage = null)
    {
        if (manga == null) return null;

        return new MangaDto
        {
            MangaId = manga.MangaId,
            Folder = manga.Folder,
            Title = manga.Title,
            ChapterNumber = manga.ChapterNumber,
            PagesCount = manga.PagesCount,
            Logo = await Path.Combine(StringConstants.MangaCollectionPath, manga.Folder, manga.Logo)
                .ResizeImageToBase64(percentage ?? FilterConstants.DefaultPercentage),
            PageExtension = manga.PageExtension,
            Tags = manga.MangaTags.Select(x => x.Tag).ToList().ToListDto(),
            Artists = manga.MangaArtists.Select(x => x.Artist).ToList().ToListDto(),
            BasePath = Path.Combine(StringConstants.BaseCollectionPath, StringConstants.MangaFolderPath, manga.Folder)
        };
    }

    public static async Task<ICollection<MangaDto>> ToListDto(this ICollection<Manga> mangas, double? percentage = null)
    {
        if (mangas == null || mangas.Count == 0) return new List<MangaDto>();

        return await Task.WhenAll(mangas.Select(x => x.ToDto(percentage)));
    }
}