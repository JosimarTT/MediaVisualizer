using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MediaVisualizer.DataAccess.Entities.Manwha;

[Table("Manwha.Manwha")]
public class Manwha : AuditEntity
{
    [Key] public int ManwhaId { get; set; }

    public string Folder { get; set; }

    public string Title { get; set; }

    public string Logos { get; set; }

    public string? Chapters { get; set; }

    public ICollection<ManwhaTag> ManwhaTags { get; set; } = new List<ManwhaTag>();

    public ICollection<ManwhaArtist> ManwhaArtists { get; set; } = new List<ManwhaArtist>();
}