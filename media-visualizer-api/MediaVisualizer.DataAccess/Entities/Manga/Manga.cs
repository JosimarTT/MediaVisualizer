using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MediaVisualizer.DataAccess.Entities.Manga;

[Table("manga.manga")]
public class Manga:AuditEntity
{
    [Key]
    [Column("manga_key")]
    public int MangaKey { get; set; }

    [Column("folder")]
    public string Folder { get; set; }

    [Column("title")]
    public string Title { get; set; }
}