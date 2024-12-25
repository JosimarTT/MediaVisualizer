using System.ComponentModel.DataAnnotations.Schema;

namespace MediaVisualizer.DataAccess.Entities;

[Table("chapter", Schema = "manwha")]
public class ManwhaChapter:AuditEntity
{
    [Column("chapter_key")]
    public int ManwhaChapterKey { get; set; }

    [Column("manwha_key")]
    public int ManwhaKey { get; set; }

    [ForeignKey(nameof(ManwhaKey))]
    public Manwha Manwha { get; set; }

    [Column("chapter_number")]
    public int ChapterNumber { get; set; }

    public ICollection<ManwhaChapterTag> ManwhaChapterTags { get; set; }

    public ICollection<ManwhaChapterArtist> ManwhaChapterArtists { get; set; }

    public ICollection<ManwhaChapterAuthor> ManwhaChapterAuthors { get; set; }

    public ICollection<ManwhaChapterBrand> ManwhaChapterBrands { get; set; }
}