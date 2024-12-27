using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MediaVisualizer.DataAccess.Entities.Shared;

namespace MediaVisualizer.DataAccess.Entities.Manwha;

public class ManwhaChapter : AuditEntity
{
    [Key] public int ManwhaChapterKey { get; set; }

    public int ManwhaKey { get; set; }

    [ForeignKey(nameof(ManwhaKey))] public Manwha Manwha { get; set; }

    public int ChapterNumber { get; set; }

    public string Logo { get; set; }
}