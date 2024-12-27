using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MediaVisualizer.DataAccess.Entities.Shared;
using Microsoft.EntityFrameworkCore;

namespace MediaVisualizer.DataAccess.Entities.Manwha;

public class ManwhaAuthor : AuditEntity
{
    public int ManwhaKey { get; set; }

    [ForeignKey(nameof(ManwhaKey))] public Manwha Manwha { get; set; }

    public int AuthorKey { get; set; }

    [ForeignKey(nameof(AuthorKey))] public Author Author { get; set; }
}