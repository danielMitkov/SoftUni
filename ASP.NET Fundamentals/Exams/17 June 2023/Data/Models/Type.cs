using Homies.Constants;
using System.ComponentModel.DataAnnotations;

namespace Homies.Data.Models;

public class Type
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(TypeConstants.NameMaxLength)]
    public string Name { get; set; } = null!;

    public IEnumerable<Event> Events { get; set; } = new List<Event>();
}
