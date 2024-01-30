using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VaporStore.Data.Models.Enums;

namespace VaporStore.Data.Models;
public class Purchase
{
    [Key]
    public int Id { get; set; }

    public PurchaseType Type { get; set; }

    [MaxLength(14)]// 3 * 4 chars + 2 dashes
    public string ProductKey { get; set; }

    public DateTime Date { get; set; }

    public int CardId { get; set; }

    [ForeignKey(nameof(CardId))]
    public Card Card { get; set; }

    public int GameId { get; set; }

    [ForeignKey(nameof(GameId))]
    public Game Game { get; set; }
}
