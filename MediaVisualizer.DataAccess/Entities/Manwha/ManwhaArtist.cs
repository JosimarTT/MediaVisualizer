using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MediaVisualizer.DataAccess.Entities.Shared;

namespace MediaVisualizer.DataAccess.Entities.Manwha;

[Table("Manwha.ManwhaArtist")]
public class ManwhaArtist
{
    [Key] public int ManwhaArtistId { get; set; }

    public int ManwhaId { get; set; }

    [ForeignKey(nameof(ManwhaId))] public Manwha Manwha { get; set; }

    public int ArtistId { get; set; }

    [ForeignKey(nameof(ArtistId))] public Artist Artist { get; set; }
}