using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MediaVisualizer.DataAccess.Entities.Manga;
using MediaVisualizer.DataAccess.Entities.Manwha;

namespace MediaVisualizer.DataAccess.Entities.Shared;

public class Author : AuditEntity
{
    [Key] public int AuthorId { get; set; }

    public string Name { get; set; }

    public ICollection<Manga.Manga> Mangas { get; set; } = new List<Manga.Manga>();

    public ICollection<Manwha.Manwha> Manwhas { get; set; } = new List<Manwha.Manwha>();
}