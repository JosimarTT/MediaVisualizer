using System.ComponentModel.DataAnnotations.Schema;
using MediaVisualizer.DataAccess.Entities.Shared;
using Microsoft.EntityFrameworkCore;

namespace MediaVisualizer.DataAccess.Entities.Manwha;

[Table("manwha.chapter_artist")]
[Keyless]
public class ManwhaChapterArtist:AuditEntity
{
    [Column("chapter_key")]
    public int ManwhaChapterKey { get; set; }

    [ForeignKey(nameof(ManwhaChapterKey))]
    public ManwhaChapter ManwhaChapter { get; set; }

    [Column("artist_key")]
    public int ArtistKey { get; set; }

    [ForeignKey(nameof(ArtistKey))]
    public Artist Artist { get; set; }
}