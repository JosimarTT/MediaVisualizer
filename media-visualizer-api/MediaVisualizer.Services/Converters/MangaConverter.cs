using MediaVisualizer.DataAccess.Entities;
using MediaVisualizer.Services.Dtos;
using MediaVisualizer.Shared;
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
            ChapterNumber = manga.ChapterNumber,
            PagesCount = manga.PagesCount,
            Logo = manga.Logo,
            PageExtension = manga.PageExtension,
            Brands = manga.Brands.ToListDto(),
            Tags = manga.Tags.ToListDto(),
            Artists = manga.Artists.ToListDto(),
            Authors = manga.Authors.ToListDto(),
            BasePath = Path.Combine(Constants.BaseCollectionFolderPath, Constants.MangaFolderPath, manga.Folder)
        };
    }

    public static ICollection<MangaDto> ToListDto(this ICollection<Manga> mangas)
    {
        if (mangas == null || mangas.Count == 0) return new List<MangaDto>();

        return mangas.Select(x => x.ToDto()).ToList();
    }
}