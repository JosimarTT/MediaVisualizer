using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MediaVisualizer.DataAccess.Entities.Shared;

namespace MediaVisualizer.DataAccess.Entities.Manga;

[Table("Manga.MangaArtist")]
public class MangaArtist
{
    [Key] public int MangaArtistId { get; set; }

    public int MangaId { get; set; }

    [ForeignKey(nameof(MangaId))] public Manga Manga { get; set; }

    public int ArtistId { get; set; }

    [ForeignKey(nameof(ArtistId))] public Artist Artist { get; set; }
}