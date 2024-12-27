using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MediaVisualizer.DataAccess.Entities.Shared;
using Microsoft.EntityFrameworkCore;

namespace MediaVisualizer.DataAccess.Entities.Anime;

public class AnimeTag : AuditEntity
{
    public int AnimeKey { get; set; }

    [ForeignKey(nameof(AnimeKey))] public Anime Anime { get; set; }

    public int TagKey { get; set; }

    [ForeignKey(nameof(TagKey))] public Tag Tag { get; set; }
}