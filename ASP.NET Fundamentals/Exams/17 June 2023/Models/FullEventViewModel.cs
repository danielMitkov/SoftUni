using Homies.Constants;
using System.ComponentModel.DataAnnotations;

namespace Homies.Models;

public class FullEventViewModel
{
    [Required]
    [MinLength(EventConstants.NameMinLength)]
    [MaxLength(EventConstants.NameMaxLength)]
    public string Name { get; set; } = null!;

    [Required]
    [MinLength(EventConstants.DescriptionMinLength)]
    [MaxLength(EventConstants.DescriptionMaxLength)]
    public string Description { get; set; } = null!;

    [Required]
    public DateTime Start { get; set; }

    [Required]
    public DateTime End { get; set; }

    [Required]
    public int TypeId { get; set; }

    public IEnumerable<TypeViewModel> Types { get; set; } = new List<TypeViewModel>();
}
