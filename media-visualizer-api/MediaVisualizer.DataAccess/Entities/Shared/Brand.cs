using System.ComponentModel.DataAnnotations.Schema;
using MediaVisualizer.DataAccess.Entities.Anime;
using MediaVisualizer.DataAccess.Entities.Manga;

namespace MediaVisualizer.DataAccess.Entities.Shared;

[Table("brand", Schema = "shared")]
public class Brand:AuditEntity
{
    [Column("brand_key")]
    public int BrandKey { get; set; }

    [Column("name")]
    public string Name { get; set; }

    public ICollection<AnimeChapterBrand> AnimeChapterBrands { get; set; }

    public ICollection<MangaChapterBrand> MangaChapterBrands { get; set; }

    public ICollection<ManwhaChapterBrand> ManwhaChapterBrands { get; set; }
}