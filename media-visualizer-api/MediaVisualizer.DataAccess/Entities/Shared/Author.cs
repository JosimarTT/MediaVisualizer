using System.ComponentModel.DataAnnotations.Schema;
using MediaVisualizer.DataAccess.Entities.Manga;

namespace MediaVisualizer.DataAccess.Entities.Shared;

[Table("author", Schema = "shared")]
public class Author:AuditEntity
{
    [Column("author_key")]
    public int AuthorKey { get; set; }

    [Column("name")]
    public string Name { get; set; }

    public ICollection<MangaChapterAuthor> MangaChapterAuthors { get; set; }

    public ICollection<ManwhaChapterAuthor> ManwhaChapterAuthors { get; set; }
}