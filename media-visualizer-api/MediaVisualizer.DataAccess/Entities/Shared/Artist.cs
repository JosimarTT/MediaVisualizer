using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MediaVisualizer.DataAccess.Entities.Manga;
using MediaVisualizer.DataAccess.Entities.Manwha;

namespace MediaVisualizer.DataAccess.Entities.Shared;

public class Artist : AuditEntity
{
    [Key] public int ArtistId { get; set; }

    public string Name { get; set; }

    public ICollection<Manga.Manga> Mangas { get; set; }

    public ICollection<Manwha.Manwha> Manwhas { get; set; }
}