using System.ComponentModel.DataAnnotations.Schema;
using MediaVisualizer.DataAccess.Entities.Shared;
using Microsoft.EntityFrameworkCore;

namespace MediaVisualizer.DataAccess.Entities.Anime;

[Table("anime.chapter_brand")]
[Keyless]
public class AnimeChapterBrand:AuditEntity
{
    [Column("chapter_key")]
    public int AnimeChapterKey { get; set; }

    [ForeignKey(nameof(AnimeChapterKey))]
    public AnimeChapter AnimeChapter { get; set; }

    [Column("brand_key")]
    public int BrandKey { get; set; }

    [ForeignKey(nameof(BrandKey))]
    public Brand Brand { get; set; }
}