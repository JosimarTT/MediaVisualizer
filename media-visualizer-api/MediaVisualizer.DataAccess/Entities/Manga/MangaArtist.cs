using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MediaVisualizer.DataAccess.Entities.Shared;
using Microsoft.EntityFrameworkCore;

namespace MediaVisualizer.DataAccess.Entities.Manga;

public class MangaArtist:AuditEntity
{
    public int MangaKey { get; set; }

    [ForeignKey(nameof(MangaKey))]
    public Manga Manga { get; set; }

    public int ArtistKey { get; set; }

    [ForeignKey(nameof(ArtistKey))]
    public Artist Artist { get; set; }
}