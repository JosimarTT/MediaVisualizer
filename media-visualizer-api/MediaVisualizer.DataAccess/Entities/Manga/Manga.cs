using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MediaVisualizer.DataAccess.Entities.Shared;

namespace MediaVisualizer.DataAccess.Entities.Manga;

public class Manga : AuditEntity
{
    [Key] public int MangaId { get; set; }

    public string Folder { get; set; }

    public string Title { get; set; }

    public ICollection<Tag> Tags { get; set; } = new List<Tag>();

    public ICollection<MangaChapter> MangaChapters { get; set; } = new List<MangaChapter>();

    public ICollection<Artist> Artists { get; set; } = new List<Artist>();

    public ICollection<Author> Authors { get; set; } = new List<Author>();

    public ICollection<Brand> Brands { get; set; } = new List<Brand>();
}