using System.ComponentModel.DataAnnotations.Schema;

namespace MediaVisualizer.DataAccess.Entities.Manga;

[Table("manga",Schema = "manga")]
public class Manga:AuditEntity
{
    [Column("manga_key")]
    public int MangaKey { get; set; }

    [Column("folder")]
    public string Folder { get; set; }

    [Column("title")]
    public string Title { get; set; }
}