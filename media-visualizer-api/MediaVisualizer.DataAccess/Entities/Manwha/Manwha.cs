using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MediaVisualizer.DataAccess.Entities.Manwha;

[Table("manwha.manwha")]
public class Manwha:AuditEntity
{
    [Key]
    [Column("manwha_key")]
    public int ManwhaKey { get; set; }

    [Column("folder")]
    public string Folder { get; set; }

    [Column("title")]
    public string Title { get; set; }
}