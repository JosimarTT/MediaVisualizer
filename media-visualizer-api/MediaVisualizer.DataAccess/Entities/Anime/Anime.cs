using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MediaVisualizer.DataAccess.Entities.Shared;

namespace MediaVisualizer.DataAccess.Entities.Anime;

public class Anime: AuditEntity
{
    [Key]
    public int AnimeKey { get; set; }

    public string Folder { get; set; }

    public string Title { get; set; }

    public ICollection<Brand> Brands { get; set; }

    public ICollection<Tag> Tags { get; set; }
}