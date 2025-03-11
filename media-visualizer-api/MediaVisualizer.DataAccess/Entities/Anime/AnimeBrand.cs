using System.ComponentModel.DataAnnotations.Schema;
using MediaVisualizer.DataAccess.Entities.Shared;

namespace MediaVisualizer.DataAccess.Entities.Anime;

[Table("Anime.AnimeBrand")]
public class AnimeBrand
{
    public int AnimeId { get; set; }

    [ForeignKey(nameof(AnimeId))] public Anime Anime { get; set; }

    public int BrandId { get; set; }

    [ForeignKey(nameof(BrandId))] public Brand Brand { get; set; }
}