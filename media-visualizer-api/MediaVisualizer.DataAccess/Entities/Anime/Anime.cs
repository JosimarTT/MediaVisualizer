using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MediaVisualizer.DataAccess.Entities.Shared;

namespace MediaVisualizer.DataAccess.Entities.Anime;

public class Anime : AuditEntity
{
    [Key] public int AnimeId { get; set; }

    public string Folder { get; set; }

    public string Title { get; set; }

    public ICollection<AnimeChapter> AnimeChapters { get; set; } = new List<AnimeChapter>();

    public ICollection<Brand> Brands { get; set; } = new List<Brand>();

    public ICollection<Tag> Tags { get; set; } = new List<Tag>();
}