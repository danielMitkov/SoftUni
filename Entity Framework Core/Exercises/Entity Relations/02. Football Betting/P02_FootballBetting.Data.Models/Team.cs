using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P02_FootballBetting.Data.Models;
public class Team
{
    public Team()
    {
        HomeGames = new HashSet<Game>();
        AwayGames = new HashSet<Game>();
        Players = new HashSet<Player>();
    }
    [Key]
    public int TeamId { get; set; }

    [Required]
    public string Name { get; set; }

    [MaxLength(2048)]
    [Required]
    public string LogoUrl { get; set; }

    [MaxLength(3)]
    [Required]
    public string Initials { get; set; }

    [Required]
    public decimal Budget { get; set; }

    [Required]
    public int PrimaryKitColorId { get; set; }

    [ForeignKey(nameof(PrimaryKitColorId))]
    public virtual Color PrimaryKitColor { get; set; }

    [Required]
    public int SecondaryKitColorId { get; set; }

    [ForeignKey(nameof(SecondaryKitColorId))]
    public virtual Color SecondaryKitColor { get; set; }

    [Required]
    public int TownId { get; set; }

    [ForeignKey(nameof(TownId))]
    public virtual Town Town { get; set; }

    [InverseProperty(nameof(Game.HomeTeam))]
    public virtual ICollection<Game> HomeGames { get; set; }

    [InverseProperty(nameof(Game.AwayTeam))]
    public virtual ICollection<Game> AwayGames { get; set; }

    public virtual ICollection<Player> Players { get; set; }
}
