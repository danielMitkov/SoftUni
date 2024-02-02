using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Theatre.Data.Models;
public class Ticket
{
    [Key]
    public int Id { get; set; }

    [Required]
    public decimal Price { get; set; }

    [Required]
    public sbyte RowNumber { get; set; }

    [Required]
    public int PlayId { get; set; }

    [Required, ForeignKey(nameof(PlayId))]
    public Play Play { get; set; }

    [Required]
    public int TheatreId { get; set; }

    [Required, ForeignKey(nameof(TheatreId))]
    public Theatre Theatre { get; set; }
}
