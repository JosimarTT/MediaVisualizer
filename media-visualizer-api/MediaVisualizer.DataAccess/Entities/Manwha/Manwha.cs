using System.ComponentModel.DataAnnotations.Schema;

namespace MediaVisualizer.DataAccess.Entities;

[Table("manwha",Schema = "manwha")]
public class Manwha:AuditEntity
{
    [Column("manwha_key")]
    public int ManwhaKey { get; set; }

    [Column("folder")]
    public string Folder { get; set; }

    [Column("title")]
    public string Title { get; set; }
}