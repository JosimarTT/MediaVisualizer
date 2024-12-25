using System.ComponentModel.DataAnnotations.Schema;
using MediaVisualizer.DataAccess.Entities.Shared;
using Microsoft.EntityFrameworkCore;

namespace MediaVisualizer.DataAccess.Entities.Anime;

[Table("anime.chapter_tag")]
[Keyless]
public class AnimeChapterTag: AuditEntity
{
    [Column("chapter_key")]
    public int AnimeChapterKey { get; set; }

    [ForeignKey(nameof(AnimeChapterKey))]
    public AnimeChapter AnimeChapter { get; set; }

    [Column("tag_key")]
    public int TagKey { get; set; }

    [ForeignKey(nameof(TagKey))]
    public Tag Tag { get; set; }
}