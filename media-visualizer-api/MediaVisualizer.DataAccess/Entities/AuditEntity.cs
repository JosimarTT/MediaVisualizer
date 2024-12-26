using System.ComponentModel.DataAnnotations.Schema;

namespace MediaVisualizer.DataAccess.Entities;

public class AuditEntity
{
    public DateTime CreatedDate { get; set; }

    public DateTime UpdatedDate { get; set; }
}