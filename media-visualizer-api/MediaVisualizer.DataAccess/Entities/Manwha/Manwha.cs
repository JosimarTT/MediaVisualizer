using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MediaVisualizer.DataAccess.Entities.Shared;

namespace MediaVisualizer.DataAccess.Entities.Manwha;

public class Manwha : AuditEntity
{
    [Key] public int ManwhaId { get; set; }

    public string Folder { get; set; }

    public string Title { get; set; }

    public ICollection<ManwhaChapter> ManwhaChapters { get; set; }

    public ICollection<Tag> Tags { get; set; }

    public ICollection<Artist> Artists { get; set; }

    public ICollection<Author> Authors { get; set; }

    public ICollection<Brand> Brands { get; set; }
}