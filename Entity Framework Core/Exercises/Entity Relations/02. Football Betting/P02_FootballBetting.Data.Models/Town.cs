using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P02_FootballBetting.Data.Models;
public class Town
{
    public Town()
    {
        Teams = new HashSet<Team>();
    }

    [Key]
    public int TownId { get; set; }

    [MaxLength(50)]
    [Required]
    public string Name { get; set; }

    [Required]
    public int CountryId { get; set; }

    [ForeignKey(nameof(CountryId))]
    public virtual Country Country { get; set; }

    public virtual ICollection<Team> Teams { get; set; }
}
