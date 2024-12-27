using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MediaVisualizer.DataAccess.Entities.Shared;
using Microsoft.EntityFrameworkCore;

namespace MediaVisualizer.DataAccess.Entities.Manga;

public class MangaBrand : AuditEntity
{
    public int MangaKey { get; set; }

    [ForeignKey(nameof(MangaKey))] public Manga Manga { get; set; }

    public int BrandKey { get; set; }

    [ForeignKey(nameof(BrandKey))] public Brand Brand { get; set; }
}