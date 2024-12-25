using System.ComponentModel.DataAnnotations.Schema;
using MediaVisualizer.DataAccess.Entities.Shared;
using Microsoft.EntityFrameworkCore;

namespace MediaVisualizer.DataAccess.Entities.Manga;

[Table("manga.chapter_brand")]
[Keyless]
public class MangaChapterBrand:AuditEntity
{
    [Column("chapter_key")]
    public int MangaChapterKey { get; set; }

    [ForeignKey(nameof(MangaChapterKey))]
    public MangaChapter MangaChapter { get; set; }

    [Column("brand_key")]
    public int BrandKey { get; set; }

    [ForeignKey(nameof(BrandKey))]
    public Brand Brand { get; set; }
}