using System.ComponentModel.DataAnnotations.Schema;
using MediaVisualizer.DataAccess.Entities.Shared;
using Microsoft.EntityFrameworkCore;

namespace MediaVisualizer.DataAccess.Entities.Manwha;

[Table("manwha.chapter_tag")]
[Keyless]
public class ManwhaChapterTag:AuditEntity
{
    [Column("chapter_key")]
    public int ManwhaChapterKey { get; set; }

    [ForeignKey(nameof(ManwhaChapterKey))]
    public ManwhaChapter ManwhaChapter { get; set; }

    [Column("tag_key")]
    public int TagKey { get; set; }

    [ForeignKey(nameof(TagKey))]
    public Tag Tag { get; set; }
}