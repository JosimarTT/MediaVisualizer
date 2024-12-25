using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MediaVisualizer.DataAccess.Entities.Manga;
using MediaVisualizer.DataAccess.Entities.Manwha;

namespace MediaVisualizer.DataAccess.Entities.Shared;

[Table("shared.artist")]
public class Artist:AuditEntity
{
    [Key]
    [Column("artist_key")]
    public int ArtistKey { get; set; }

    [Column("name")]
    public string Name { get; set; }

    public ICollection<MangaChapter> MangaChapters { get; set; }

    public ICollection<ManwhaChapter> ManwhaChapters  { get; set; }
}