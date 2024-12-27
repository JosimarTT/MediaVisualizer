using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MediaVisualizer.DataAccess.Entities.Shared;

namespace MediaVisualizer.DataAccess.Entities.Manga;

public class MangaChapter : AuditEntity
{
    [Key] public int MangaChapterKey { get; set; }

    public int MangaKey { get; set; }

    [ForeignKey(nameof(MangaKey))] public Manga Manga { get; set; }

    public int ChapterNumber { get; set; }

    public string Logo { get; set; }
}