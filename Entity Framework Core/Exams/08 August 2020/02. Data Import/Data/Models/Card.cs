using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VaporStore.Data.Models.Enums;

namespace VaporStore.Data.Models;
public class Card
{
    public Card()
    {
        Purchases = new HashSet<Purchase>();
    }
    [Key]
    public int Id { get; set; }

    [MaxLength(19)]// 4 * 4 digits + 3 spaces
    public string Number { get; set; }

    [MaxLength(3)]
    public string Cvc { get; set; }

    public CardType Type { get; set; }

    public int UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public User User { get; set; }

    public ICollection<Purchase> Purchases { get; set; }
}
