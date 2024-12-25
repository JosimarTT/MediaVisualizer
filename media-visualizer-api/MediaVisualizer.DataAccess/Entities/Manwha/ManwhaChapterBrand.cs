using System.ComponentModel.DataAnnotations.Schema;
using MediaVisualizer.DataAccess.Entities.Shared;

namespace MediaVisualizer.DataAccess.Entities;

[Table("chapter_brand", Schema = "manwha")]
public class ManwhaChapterBrand:AuditEntity
{
    [Column("chapter_key")]
    public int ManwhaChapterKey { get; set; }

    [ForeignKey(nameof(ManwhaChapterKey))]
    public ManwhaChapter ManwhaChapter { get; set; }

    [Column("brand_key")]
    public int BrandKey { get; set; }

    [ForeignKey(nameof(BrandKey))]
    public Brand Brand { get; set; }
}