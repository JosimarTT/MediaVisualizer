using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MediaVisualizer.DataAccess.Entities.Anime;
using MediaVisualizer.DataAccess.Entities.Manga;
using MediaVisualizer.DataAccess.Entities.Manwha;

namespace MediaVisualizer.DataAccess.Entities.Shared;

[Table("Shared.Tag")]
public class Tag : AuditEntity
{
    [Key] public int TagId { get; set; }

    public string Name { get; set; }

    public ICollection<AnimeTag> AnimeTags { get; set; } = new List<AnimeTag>();

    public ICollection<MangaTag> MangaTags { get; set; } = new List<MangaTag>();

    public ICollection<ManwhaTag> ManwhaTags { get; set; } = new List<ManwhaTag>();
}