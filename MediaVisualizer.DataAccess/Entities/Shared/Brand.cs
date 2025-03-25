using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MediaVisualizer.DataAccess.Entities.Anime;

namespace MediaVisualizer.DataAccess.Entities.Shared;

[Table("Shared.Brand")]
public class Brand : AuditEntity
{
    [Key] public int BrandId { get; set; }

    public string Name { get; set; }

    public ICollection<AnimeBrand> AnimeBrands { get; set; } = new List<AnimeBrand>();
}