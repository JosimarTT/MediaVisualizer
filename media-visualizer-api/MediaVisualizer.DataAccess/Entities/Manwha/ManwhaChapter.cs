using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MediaVisualizer.DataAccess.Entities.Shared;

namespace MediaVisualizer.DataAccess.Entities.Manwha;

[Table("manwha.chapter")]
public class ManwhaChapter:AuditEntity
{
    [Key]
    [Column("chapter_key")]
    public int ManwhaChapterKey { get; set; }

    [Column("manwha_key")]
    public int ManwhaKey { get; set; }

    [ForeignKey(nameof(ManwhaKey))]
    public Entities.Manwha.Manwha Manwha { get; set; }

    [Column("chapter_number")]
    public int ChapterNumber { get; set; }

    public ICollection<Tag> Tags { get; set; }

    public ICollection<Artist> Artists { get; set; }

    public ICollection<Author> Authors { get; set; }

    public ICollection<Brand> Brands { get; set; }
}