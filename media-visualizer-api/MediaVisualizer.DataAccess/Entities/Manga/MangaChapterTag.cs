using System.ComponentModel.DataAnnotations.Schema;
using MediaVisualizer.DataAccess.Entities.Shared;

namespace MediaVisualizer.DataAccess.Entities.Manga;

[Table("chapter_tag", Schema = "manga")]
public class MangaChapterTag : AuditEntity
{
    [Column("chapter_key")]
    public int MangaChapterKey { get; set; }

    [ForeignKey(nameof(MangaChapterKey))]
    public MangaChapter MangaChapter { get; set; }

    [Column("tag_key")]
    public int TagKey { get; set; }

    [ForeignKey(nameof(TagKey))]
    public Tag Tag { get; set; }
}