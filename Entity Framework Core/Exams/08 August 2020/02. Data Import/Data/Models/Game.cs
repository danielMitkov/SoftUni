using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VaporStore.Data.Models;
public class Game
{
    public Game()
    {
        Purchases = new HashSet<Purchase>();
        GameTags = new HashSet<GameTag>();
    }
    [Key]
    public int Id { get; set; }

    public string Name { get; set; }

    public decimal Price { get; set; }

    public DateTime ReleaseDate { get; set; }

    public int DeveloperId { get; set; }

    [ForeignKey(nameof(DeveloperId))]
    public Developer Developer { get; set; }

    public int GenreId { get; set; }

    [ForeignKey(nameof(GenreId))]
    public Genre Genre { get; set; }

    public ICollection<Purchase> Purchases { get; set; }

    public ICollection<GameTag> GameTags { get; set; }
}
