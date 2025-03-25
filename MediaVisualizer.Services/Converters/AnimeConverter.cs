using MediaVisualizer.DataAccess.Entities.Anime;
using MediaVisualizer.Services.Converters;
using MediaVisualizer.Services.Dtos;
using MediaVisualizer.Shared;
using MediaVisualizer.Shared.ExtensionMethods;

public static class AnimeConverter
{
    public static async Task<AnimeDto> ToDto(this Anime anime)
    {
        if (anime == null) return null;
        return new AnimeDto
        {
            AnimeId = anime.AnimeId,
            Folder = anime.Folder,
            Title = anime.Title,
            ChapterNumber = anime.ChapterNumber,
            Logo = await Path.Combine(StringConstants.AnimeCollectionPath, anime.Folder, anime.Logo).GetBase64Image(),
            Video = anime.Video,
            Brands = anime.AnimeBrands.Select(ab => ab.Brand).ToList().ToListDto(),
            Tags = anime.AnimeTags.Select(at => at.Tag).ToList().ToListDto(),
            BasePath = Path.Combine(StringConstants.BaseCollectionPath, StringConstants.AnimeFolderPath, anime.Folder)
        };
    }

    public static async Task<ICollection<AnimeDto>> ToListDto(this ICollection<Anime> animes)
    {
        if (animes == null || animes.Count == 0) return new List<AnimeDto>();

        return await Task.WhenAll(animes.Select(x => x.ToDto()));
    }

    public static Anime ToEntity(this AnimeDto animeDto)
    {
        if (animeDto == null) return null;

        return new Anime
        {
            AnimeId = animeDto.AnimeId,
            Folder = animeDto.Folder,
            Title = animeDto.Title,
            ChapterNumber = animeDto.ChapterNumber,
            Logo = animeDto.Logo,
            Video = animeDto.Video,
            AnimeBrands = animeDto.Brands.Select(b => new AnimeBrand { BrandId = b.BrandId }).ToList(),
            AnimeTags = animeDto.Tags.Select(t => new AnimeTag { TagId = t.TagId }).ToList()
        };
    }
}