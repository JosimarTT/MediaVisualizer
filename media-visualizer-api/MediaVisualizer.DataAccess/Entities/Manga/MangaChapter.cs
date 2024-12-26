using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MediaVisualizer.DataAccess.Entities.Shared;

namespace MediaVisualizer.DataAccess.Entities.Manga;

[Table("manga.chapter")]
public class MangaChapter: AuditEntity
{
    [Key]
    [Column("chapter_key")]
    public int MangaChapterKey { get; set; }

    [Column("manga_key")]
    public int MangaKey { get; set; }

    [ForeignKey(nameof(MangaKey))]
    public Manga Manga { get; set; }

    [Column("chapter_number")]
    public int ChapterNumber { get; set; }

    public ICollection<Tag> Tags { get; set; }

    public ICollection<Artist> Artists { get; set; }

   public ICollection<Author> Authors { get; set; }

   public ICollection<Brand> Brands { get; set; }
}