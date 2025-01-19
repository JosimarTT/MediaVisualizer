using System.ComponentModel.DataAnnotations;

namespace MediaVisualizer.DataAccess.Entities;

public class Artist : AuditEntity
{
    [Key] public int ArtistId { get; set; }

    public string Name { get; set; }

    public ICollection<Manga> Mangas { get; set; } = new List<Manga>();

    public ICollection<Manwha> Manwhas { get; set; } = new List<Manwha>();
}