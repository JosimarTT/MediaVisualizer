using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MediaVisualizer.DataAccess.Entities.Shared;

namespace MediaVisualizer.DataAccess.Entities.Manwha;

[Table("Manwha.ManwhaTag")]
public class ManwhaTag
{
    [Key] public int ManwhaTagId { get; set; }

    public int ManwhaId { get; set; }

    [ForeignKey(nameof(ManwhaId))] public Manwha Manwha { get; set; }

    public int TagId { get; set; }

    [ForeignKey(nameof(TagId))] public Tag Tag { get; set; }
}