using System.ComponentModel.DataAnnotations.Schema;
using MediaVisualizer.DataAccess.Entities.Shared;

namespace MediaVisualizer.DataAccess.Entities.Manga;

[Table("chapter_artist", Schema = "manga")]
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