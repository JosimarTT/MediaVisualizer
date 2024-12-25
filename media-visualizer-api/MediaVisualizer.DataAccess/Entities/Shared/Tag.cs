using System.ComponentModel.DataAnnotations.Schema;
using MediaVisualizer.DataAccess.Entities.Anime;
using MediaVisualizer.DataAccess.Entities.Manga;

namespace MediaVisualizer.DataAccess.Entities.Shared;

[Table("tag", Schema = "shared")]
public class Tag:AuditEntity
{
    [Column("tag_key")]
    public int TagKey { get; set; }

    [Column("name")]
    public string Name { get; set; }

    public ICollection<AnimeChapterTag> AnimeChapterTags { get; set; }

    public ICollection<ManwhaChapterTag> ManwhaChapterTags { get; set; }

    public ICollection<MangaChapterTag> MangaChapterTags { get; set; }
}