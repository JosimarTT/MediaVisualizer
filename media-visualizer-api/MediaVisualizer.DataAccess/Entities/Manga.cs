namespace MediaVisualizer.DataAccess.Entities;

public class Manga : AuditEntity
{
    public int MangaId { get; set; }

    public string Folder { get; set; }

    public string Title { get; set; }

    public int ChapterNumber { get; set; }

    public string Logo { get; set; }

    public string PageExtension { get; set; }

    public int PagesCount { get; set; }

    public ICollection<Tag> Tags { get; set; } = new List<Tag>();

    public ICollection<Artist> Artists { get; set; } = new List<Artist>();

    public ICollection<Author> Authors { get; set; } = new List<Author>();

    public ICollection<Brand> Brands { get; set; } = new List<Brand>();
}