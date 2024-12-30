using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MediaVisualizer.DataAccess.Entities.Anime;
using MediaVisualizer.DataAccess.Entities.Manga;
using MediaVisualizer.DataAccess.Entities.Manwha;

namespace MediaVisualizer.DataAccess.Entities.Shared;

public class Brand : AuditEntity
{
    [Key] public int BrandId { get; set; }

    public string Name { get; set; }

    public ICollection<Anime.Anime> Animes { get; set; }

    public ICollection<Manga.Manga> Mangas { get; set; }

    public ICollection<Manwha.Manwha> Manwhas { get; set; }
}