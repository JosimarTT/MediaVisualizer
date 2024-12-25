using System.ComponentModel.DataAnnotations.Schema;
using MediaVisualizer.DataAccess.Entities.Shared;
using Microsoft.EntityFrameworkCore;

namespace MediaVisualizer.DataAccess.Entities.Manwha;

[Table("manwha.chapter_author")]
[Keyless]
public class ManwhaChapterAuthor:AuditEntity
{
    [Column("chapter_key")]
    public int ManwhaChapterKey { get; set; }

    [ForeignKey(nameof(ManwhaChapterKey))]
    public ManwhaChapter ManwhaChapter { get; set; }

    [Column("author_key")]
    public int AuthorKey { get; set; }

    [ForeignKey(nameof(AuthorKey))]
    public Author Author { get; set; }
}