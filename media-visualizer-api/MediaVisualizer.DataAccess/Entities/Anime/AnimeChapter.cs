using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MediaVisualizer.DataAccess.Entities.Shared;

namespace MediaVisualizer.DataAccess.Entities.Anime;

[Table("anime.chapter")]
public class AnimeChapter: AuditEntity
{
    [Key]
    [Column("chapter_key")]
    public int AnimeChapterKey { get; set; }

    [Column("anime_key")]
    public int AnimeKey { get; set; }

    [ForeignKey(nameof(AnimeKey))]
    public Anime Anime { get; set; }

    [Column("chapter_number")]
    public int ChapterNumber { get; set; }

    public ICollection<Brand> Brands { get; set; }

    public ICollection<Tag> Tags { get; set; }
}