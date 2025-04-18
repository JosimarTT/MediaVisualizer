﻿using MediaVisualizer.DataAccess.Entities.Manga;
using MediaVisualizer.Services.Dtos;
using MediaVisualizer.Shared;

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
            Logo = Path.Combine(StringConstants.MangaCollectionPath, manga.Folder, manga.Logo),
            PageExtension = manga.PageExtension,
            Tags = manga.MangaTags.Select(x => x.Tag).ToList().ToListDto(),
            Artists = manga.MangaArtists.Select(x => x.Artist).ToList().ToListDto(),
            BasePath = Path.Combine(StringConstants.MangaCollectionPath, manga.Folder)
        };
    }

    public static IEnumerable<MangaDto> ToListDto(this ICollection<Manga> mangas)
    {
        if (mangas == null || mangas.Count == 0) return new List<MangaDto>();

        return mangas.Select(x => x.ToDto());
    }
}