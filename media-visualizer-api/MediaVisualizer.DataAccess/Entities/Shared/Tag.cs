using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MediaVisualizer.DataAccess.Entities.Anime;
using MediaVisualizer.DataAccess.Entities.Manga;
using MediaVisualizer.DataAccess.Entities.Manwha;

namespace MediaVisualizer.DataAccess.Entities.Shared;

[Table("shared.tag")]
public class Tag:AuditEntity
{
    [Key]
    [Column("tag_key")]
    public int TagKey { get; set; }

    [Column("name")]
    public string Name { get; set; }

    public ICollection<AnimeChapter> AnimeChapters { get; set; }

    public ICollection<ManwhaChapter> ManwhaChapters { get; set; }

    public ICollection<MangaChapter> MangaChapters { get; set; }
}