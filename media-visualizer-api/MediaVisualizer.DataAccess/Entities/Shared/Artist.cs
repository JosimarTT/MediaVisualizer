using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MediaVisualizer.DataAccess.Entities.Manga;
using MediaVisualizer.DataAccess.Entities.Manwha;

namespace MediaVisualizer.DataAccess.Entities.Shared;

[Table("Shared.Artist")]
public class Artist : AuditEntity
{
    [Key] public int ArtistId { get; set; }

    public string Name { get; set; }

    public ICollection<MangaArtist> MangaArtists { get; set; } = new List<MangaArtist>();

    public ICollection<ManwhaArtist> ManwhaArtists { get; set; } = new List<ManwhaArtist>();
}