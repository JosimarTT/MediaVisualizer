using System.ComponentModel.DataAnnotations.Schema;
using MediaVisualizer.DataAccess.Entities.Shared;

namespace MediaVisualizer.DataAccess.Entities;

[Table("chapter_author", Schema = "manwha")]
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