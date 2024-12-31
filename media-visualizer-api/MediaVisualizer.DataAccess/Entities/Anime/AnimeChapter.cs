using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MediaVisualizer.DataAccess.Entities.Shared;

namespace MediaVisualizer.DataAccess.Entities.Anime;

public class AnimeChapter : AuditEntity
{
    [Key] public int AnimeChapterId { get; set; }

    public int AnimeId { get; set; }

    [ForeignKey(nameof(AnimeId))] public Anime Anime { get; set; }

    public int ChapterNumber { get; set; }

    public string Logo { get; set; }

    public string Video { get; set; }
}