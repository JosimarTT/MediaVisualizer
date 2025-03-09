using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MediaVisualizer.DataAccess.Entities.Shared;

namespace MediaVisualizer.DataAccess.Entities.Anime;

[Table("Anime.AnimeTag")]
public class AnimeTag
{
    [Key] public int AnimeTagId { get; set; }

    public int AnimeId { get; set; }

    [ForeignKey(nameof(AnimeId))] public Anime Anime { get; set; }

    public int TagId { get; set; }

    [ForeignKey(nameof(TagId))] public Tag Tag { get; set; }
}