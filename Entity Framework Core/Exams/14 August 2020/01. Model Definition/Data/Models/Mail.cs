using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftJail.Data.Models;
public class Mail
{
    [Key]
    public int Id { get; set; }

    public string Description { get; set; }

    public string Sender { get; set; }

    public string Address { get; set; }

    public int PrisonerId { get; set; }

    [ForeignKey(nameof(PrisonerId))]
    public Prisoner Prisoner { get; set; }
}
