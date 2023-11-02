using System.ComponentModel.DataAnnotations;

namespace P02_FootballBetting.Data.Models;
public class User
{
    public User()
    {
        Bets = new HashSet<Bet>();
    }

    [Key]
    public int UserId { get; set; }

    [MaxLength(50)]
    [Required]
    public string Username { get; set; }

    [MaxLength(100)]
    [Required]
    public string Password { get; set; }

    [MaxLength(50)]
    [Required]
    public string Email { get; set; }

    [MaxLength(50)]
    [Required]
    public string Name { get; set; }

    [Required]
    public decimal Balance { get; set; }

    public virtual ICollection<Bet> Bets { get; set; }
}
