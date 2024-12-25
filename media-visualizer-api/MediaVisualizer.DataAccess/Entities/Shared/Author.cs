using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MediaVisualizer.DataAccess.Entities.Manga;
using MediaVisualizer.DataAccess.Entities.Manwha;

namespace MediaVisualizer.DataAccess.Entities.Shared;

[Table("shared.author")]
public class Author:AuditEntity
{
    [Key]
    [Column("author_key")]
    public int AuthorKey { get; set; }

    [Column("name")]
    public string Name { get; set; }

    public ICollection<MangaChapter> MangaChapters { get; set; }

    public ICollection<ManwhaChapter> ManwhaChapters { get; set; }
}