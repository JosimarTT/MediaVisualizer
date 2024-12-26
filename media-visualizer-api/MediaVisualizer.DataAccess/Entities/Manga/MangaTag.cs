using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MediaVisualizer.DataAccess.Entities.Shared;
using Microsoft.EntityFrameworkCore;

namespace MediaVisualizer.DataAccess.Entities.Manga;

public class MangaTag : AuditEntity
{
    public int MangaKey { get; set; }

    [ForeignKey(nameof(MangaKey))]
    public Manga Manga { get; set; }

    public int TagKey { get; set; }

    [ForeignKey(nameof(TagKey))]
    public Tag Tag { get; set; }
}