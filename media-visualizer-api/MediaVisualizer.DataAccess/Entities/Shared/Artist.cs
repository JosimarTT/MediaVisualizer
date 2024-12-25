using System.ComponentModel.DataAnnotations.Schema;
using MediaVisualizer.DataAccess.Entities.Manga;

namespace MediaVisualizer.DataAccess.Entities.Shared;

[Table("artist", Schema = "shared")]
public class Artist:AuditEntity
{
    [Column("artist_key")]
    public int ArtistKey { get; set; }

    [Column("name")]
    public string Name { get; set; }

    public ICollection<MangaChapterArtist> MangaChapterArtists { get; set; }

    public ICollection<ManwhaChapterArtist> ManwhaChapterArtists  { get; set; }
}