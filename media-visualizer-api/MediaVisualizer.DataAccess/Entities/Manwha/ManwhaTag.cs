using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MediaVisualizer.DataAccess.Entities.Shared;
using Microsoft.EntityFrameworkCore;

namespace MediaVisualizer.DataAccess.Entities.Manwha;

public class ManwhaTag:AuditEntity
{
    public int ManwhaKey { get; set; }

    [ForeignKey(nameof(ManwhaKey))]
    public Manwha Manwha { get; set; }

    public int TagKey { get; set; }

    [ForeignKey(nameof(TagKey))]
    public Tag Tag { get; set; }
}