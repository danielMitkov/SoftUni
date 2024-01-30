using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace VaporStore.Data.Models;
public class GameTag
{
    public int GameId { get; set; }

    [ForeignKey(nameof(GameId))]
    public Game Game { get; set; }

    public int TagId { get; set; }

    [ForeignKey(nameof(TagId))]
    public Tag Tag { get; set; }
}
