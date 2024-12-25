using System.ComponentModel.DataAnnotations.Schema;
using MediaVisualizer.DataAccess.Entities.Shared;

namespace MediaVisualizer.DataAccess.Entities.Anime;

[Table("chapter",Schema = "anime")]
public class AnimeChapter: AuditEntity
{
    [Column("chapter_key")]
    public int AnimeChapterKey { get; set; }

    [Column("anime_key")]
    public int AnimeKey { get; set; }

    [ForeignKey(nameof(AnimeKey))]
    public Anime Anime { get; set; }

    [Column("chapter_number")]
    public int ChapterNumber { get; set; }

    public ICollection<AnimeChapterBrand> AnimeChapterBrands { get; set; }

    public ICollection<AnimeChapterTag> AnimeChapterTags { get; set; }
}