using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MediaVisualizer.DataAccess.Entities.Shared;
using Microsoft.EntityFrameworkCore;

namespace MediaVisualizer.DataAccess.Entities.Manwha;

public class ManwhaBrand:AuditEntity
{
    public int ManwhaKey { get; set; }

    [ForeignKey(nameof(ManwhaKey))]
    public Manwha Manwha { get; set; }

    public int BrandKey { get; set; }

    [ForeignKey(nameof(BrandKey))]
    public Brand Brand { get; set; }
}