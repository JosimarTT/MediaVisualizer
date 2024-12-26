using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MediaVisualizer.DataAccess.Entities.Shared;
using Microsoft.EntityFrameworkCore;

namespace MediaVisualizer.DataAccess.Entities.Anime;

[Table("anime.chapter_tag")]
public class AnimeChapterTag: AuditEntity
{
    [Key, Column("chapter_key", Order = 0)]
    public int AnimeChapterKey { get; set; }

    [ForeignKey(nameof(AnimeChapterKey))]
    public AnimeChapter AnimeChapter { get; set; }

    [Key, Column("tag_key", Order = 1)]
    public int TagKey { get; set; }

    [ForeignKey(nameof(TagKey))]
    public Tag Tag { get; set; }
}