using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftJail.Data.Models;

public class Prisoner
{
    [Key]
    public int Id { get; set; }

    [MaxLength(20)]
    public string FullName { get; set; }

    public string Nickname { get; set; }

    public int Age { get; set; }

    public DateTime IncarcerationDate { get; set; }

    public DateTime? ReleaseDate { get; set; }

    public decimal? Bail { get; set; }

    public int? CellId { get; set; }

    [ForeignKey(nameof(CellId))]
    public Cell Cell { get; set; }

    public ICollection<Mail> Mails { get; set; }

    public ICollection<OfficerPrisoner> PrisonerOfficers { get; set; }
}
