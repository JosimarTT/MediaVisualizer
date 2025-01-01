using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MediaVisualizer.DataAccess.Entities.Shared;

namespace MediaVisualizer.DataAccess.Entities.Manwha;

public class Manwha : AuditEntity
{
    [Key] public int ManwhaId { get; set; }

    public string Folder { get; set; }

    public string Title { get; set; }

    public string Logos { get; set; }

    public ICollection<ManwhaChapter> ManwhaChapters { get; set; } = new List<ManwhaChapter>();

    public ICollection<Tag> Tags { get; set; } = new List<Tag>();

    public ICollection<Artist> Artists { get; set; } = new List<Artist>();

    public ICollection<Author> Authors { get; set; } = new List<Author>();

    public ICollection<Brand> Brands { get; set; } = new List<Brand>();
}