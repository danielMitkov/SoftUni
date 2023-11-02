using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P02_FootballBetting.Data.Models;
public class Player
{
    public Player()
    {
        PlayersStatistics = new HashSet<PlayerStatistic>();
    }

    [Key]
    public int PlayerId { get; set; }

    [MaxLength(50)]
    [Required]
    public string Name { get; set; }

    [Required]
    public int SquadNumber { get; set; }

    [Required]
    public bool IsInjured { get; set; }

    [Required]
    public int TeamId { get; set; }

    [ForeignKey(nameof(TeamId))]
    public virtual Team Team { get; set; }

    [Required]
    public int PositionId { get; set; }

    [ForeignKey(nameof(PositionId))]
    public virtual Position Position { get; set; }

    public virtual ICollection<PlayerStatistic> PlayersStatistics { get; set; }
}
