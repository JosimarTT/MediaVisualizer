using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MediaVisualizer.DataAccess.Entities.Shared;

namespace MediaVisualizer.DataAccess.Entities.Manga;

public class MangaChapter : AuditEntity
{
    [Key] public int MangaChapterId { get; set; }

    public int MangaId { get; set; }

    [ForeignKey(nameof(MangaId))] public Manga Manga { get; set; }

    public int ChapterNumber { get; set; }

    public int PagesCount { get; set; }

    public string Logo { get; set; }

    public string PageExtension { get; set; }
}