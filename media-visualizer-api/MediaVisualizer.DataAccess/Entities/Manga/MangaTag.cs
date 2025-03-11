using System.ComponentModel.DataAnnotations.Schema;
using MediaVisualizer.DataAccess.Entities.Shared;

namespace MediaVisualizer.DataAccess.Entities.Manga;

[Table("Manga.MangaTag")]
public class MangaTag
{
    public int MangaId { get; set; }

    [ForeignKey(nameof(MangaId))] public Manga Manga { get; set; }

    public int TagId { get; set; }

    [ForeignKey(nameof(TagId))] public Tag Tag { get; set; }
}