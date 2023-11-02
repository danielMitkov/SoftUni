using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace P02_FootballBetting.Data.Models;
public class Bet
{
    [Key]
    public int BetId { get; set; }

    [Required]
    public decimal Amount { get; set; }

    [MaxLength(50)]
    [Required]
    public string Prediction { get; set; }

    [Required]
    public DateTime DateTime { get; set; }

    [Required]
    public int UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public virtual User User { get; set; }

    [Required]
    public int GameId { get; set; }

    [ForeignKey(nameof(GameId))]
    public virtual Game Game { get; set; }
}
