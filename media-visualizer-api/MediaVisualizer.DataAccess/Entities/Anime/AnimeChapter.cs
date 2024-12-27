using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MediaVisualizer.DataAccess.Entities.Shared;

namespace MediaVisualizer.DataAccess.Entities.Anime;

public class AnimeChapter : AuditEntity
{
    [Key] public int AnimeChapterKey { get; set; }

    public int AnimeKey { get; set; }

    [ForeignKey(nameof(AnimeKey))] public Anime Anime { get; set; }

    public int ChapterNumber { get; set; }

    public string Logo { get; set; }
}