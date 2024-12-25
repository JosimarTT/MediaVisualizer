using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MediaVisualizer.DataAccess.Entities.Anime;
using MediaVisualizer.DataAccess.Entities.Manga;
using MediaVisualizer.DataAccess.Entities.Manwha;

namespace MediaVisualizer.DataAccess.Entities.Shared;

[Table("shared.brand")]
public class Brand:AuditEntity
{
    [Key]
    [Column("brand_key")]
    public int BrandKey { get; set; }

    [Column("name")]
    public string Name { get; set; }

    public ICollection<AnimeChapter> AnimeChapter { get; set; }

    public ICollection<MangaChapter> MangaChapter { get; set; }

    public ICollection<ManwhaChapter> ManwhaChapter { get; set; }
}