using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MediaVisualizer.DataAccess.Entities;

public class ManwhaChapter : AuditEntity
{
    [Key] public int ManwhaChapterId { get; set; }

    public int ManwhaId { get; set; }

    [ForeignKey(nameof(ManwhaId))] public Manwha Manwha { get; set; }

    public int ChapterNumber { get; set; }

    public int PagesCount { get; set; }

    public string Logo { get; set; }

    public string PageExtension { get; set; }
}