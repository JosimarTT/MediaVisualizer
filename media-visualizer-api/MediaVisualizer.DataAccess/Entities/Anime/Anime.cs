using System.ComponentModel.DataAnnotations.Schema;

namespace MediaVisualizer.DataAccess.Entities.Anime;

[Table("anime",Schema = "anime")]
public class Anime: AuditEntity
{
    [Column("anime_key")]
    public int AnimeKey { get; set; }

    [Column("folder")]
    public string Folder { get; set; }

    [Column("title")]
    public string Title { get; set; }
}