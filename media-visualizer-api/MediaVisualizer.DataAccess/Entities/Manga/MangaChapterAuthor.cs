using System.ComponentModel.DataAnnotations.Schema;
using MediaVisualizer.DataAccess.Entities.Shared;

namespace MediaVisualizer.DataAccess.Entities.Manga;

[Table("chapter_author", Schema = "manga")]
public class MangaChapterAuthor: AuditEntity
{
    [Column("chapter_key")]
    public int MangaChapterKey { get; set; }

    [ForeignKey(nameof(MangaChapterKey))]
    public MangaChapter MangaChapter { get; set; }

    [Column("author_key")]
    public int AuthorKey { get; set; }

    [ForeignKey(nameof(AuthorKey))]
    public Author Author { get; set; }
}