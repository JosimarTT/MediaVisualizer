using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MediaVisualizer.DataAccess.Entities.Shared;
using Microsoft.EntityFrameworkCore;

namespace MediaVisualizer.DataAccess.Entities.Anime;

[Table("anime.chapter_brand")]
public class AnimeChapterBrand:AuditEntity
{
    [Key, Column("chapter_key", Order = 0)]
    public int AnimeChapterKey { get; set; }

    [ForeignKey(nameof(AnimeChapterKey))]
    public AnimeChapter AnimeChapter { get; set; }

    [Key, Column("brand_key", Order = 1)]
    public int BrandKey { get; set; }

    [ForeignKey(nameof(BrandKey))]
    public Brand Brand { get; set; }
}