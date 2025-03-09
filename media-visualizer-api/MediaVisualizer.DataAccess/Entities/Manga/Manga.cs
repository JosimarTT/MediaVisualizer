using System.ComponentModel.DataAnnotations.Schema;

namespace MediaVisualizer.DataAccess.Entities.Manga;

[Table("Manga.Manga")]
public class Manga : AuditEntity
{
    public int MangaId { get; set; }

    public string Folder { get; set; }

    public string Title { get; set; }

    public int ChapterNumber { get; set; }

    public string Logo { get; set; }

    public string PageExtension { get; set; }

    public int PagesCount { get; set; }

    public ICollection<MangaTag> MangaTags { get; set; } = new List<MangaTag>();

    public ICollection<MangaArtist> MangaArtists { get; set; } = new List<MangaArtist>();
}