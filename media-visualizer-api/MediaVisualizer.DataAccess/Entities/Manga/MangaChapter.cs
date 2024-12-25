using System.ComponentModel.DataAnnotations.Schema;
using MediaVisualizer.DataAccess.Entities.Shared;

namespace MediaVisualizer.DataAccess.Entities.Manga;

[Table("chapter", Schema = "manga")]
public class MangaChapter: AuditEntity
{
    [Column("chapter_key")]
    public int MangaChapterKey { get; set; }

    [Column("manga_key")]
    public int MangaKey { get; set; }

    [ForeignKey(nameof(MangaKey))]
    public Manga Manga { get; set; }

    [Column("chapter_number")]
    public int ChapterNumber { get; set; }

    public ICollection<MangaChapterTag> MangaChapterTags { get; set; }

    public ICollection<MangaChapterArtist> MangaChapterArtists { get; set; }

   public ICollection<MangaChapterAuthor> MangaChapterAuthors { get; set; }

   public ICollection<MangaChapterBrand> MangaChapterBrands { get; set; }
}