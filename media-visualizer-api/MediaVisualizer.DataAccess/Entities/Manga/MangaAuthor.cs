using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MediaVisualizer.DataAccess.Entities.Shared;
using Microsoft.EntityFrameworkCore;

namespace MediaVisualizer.DataAccess.Entities.Manga;

public class MangaAuthor: AuditEntity
{
    public int MangaKey { get; set; }

    [ForeignKey(nameof(MangaKey))]
    public Manga Manga { get; set; }

    public int AuthorKey { get; set; }

    [ForeignKey(nameof(AuthorKey))]
    public Author Author { get; set; }
}