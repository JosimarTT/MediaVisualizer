using System.ComponentModel.DataAnnotations.Schema;
using MediaVisualizer.DataAccess.Entities.Shared;
using Microsoft.EntityFrameworkCore;

namespace MediaVisualizer.DataAccess.Entities.Manga;

[Table("manga.chapter_artist")]
[Keyless]
public class MangaChapterArtist
{
    [Column("chapter_key")]
    public int MangaChapterKey { get; set; }

    [ForeignKey(nameof(MangaChapterKey))]
    public MangaChapter MangaChapter { get; set; }

    [Column("artist_key")]
    public int ArtistKey { get; set; }

    [ForeignKey(nameof(ArtistKey))]
    public Artist Artist { get; set; }
}