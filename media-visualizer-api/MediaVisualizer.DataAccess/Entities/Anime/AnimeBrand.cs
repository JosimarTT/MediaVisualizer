using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MediaVisualizer.DataAccess.Entities.Shared;
using Microsoft.EntityFrameworkCore;

namespace MediaVisualizer.DataAccess.Entities.Anime;

public class AnimeBrand : AuditEntity
{
    public int AnimeKey { get; set; }

    [ForeignKey(nameof(AnimeKey))] public Anime Anime { get; set; }

    public int BrandKey { get; set; }

    [ForeignKey(nameof(BrandKey))] public Brand Brand { get; set; }
}