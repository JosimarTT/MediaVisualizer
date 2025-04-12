using System.ComponentModel.DataAnnotations.Schema;

namespace MediaVisualizer.DataAccess.Entities.Anime;

[Table("Anime.Anime")]
public class Anime : AuditEntity
{
    public int AnimeId { get; set; }

    public string Folder { get; set; }

    public string Title { get; set; }

    public int ChapterNumber { get; set; }

    public string Logo { get; set; }

    public string Video { get; set; }

    public ICollection<AnimeBrand> AnimeBrands { get; set; } = new List<AnimeBrand>();

    public ICollection<AnimeTag> AnimeTags { get; set; } = new List<AnimeTag>();
}