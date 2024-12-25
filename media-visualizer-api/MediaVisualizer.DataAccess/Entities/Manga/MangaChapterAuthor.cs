using System.ComponentModel.DataAnnotations.Schema;
using MediaVisualizer.DataAccess.Entities.Shared;
using Microsoft.EntityFrameworkCore;

namespace MediaVisualizer.DataAccess.Entities.Manga;

[Table("manga.chapter_author")]
[Keyless]
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