using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MediaVisualizer.DataAccess.Entities.Shared;
using Microsoft.EntityFrameworkCore;

namespace MediaVisualizer.DataAccess.Entities.Manwha;

public class ManwhaArtist : AuditEntity
{
    public int ManwhaKey { get; set; }

    [ForeignKey(nameof(ManwhaKey))] public Manwha Manwha { get; set; }

    public int ArtistKey { get; set; }

    [ForeignKey(nameof(ArtistKey))] public Artist Artist { get; set; }
}