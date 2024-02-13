using SoftUniBazar.Data.Constants;
using SoftUniBazar.Models.CategoryModels;
using System.ComponentModel.DataAnnotations;

namespace SoftUniBazar.Models.AdModels;

public class AdFormViewModel
{
    [Required]
    [StringLength(AdConstants.NameMax,
        MinimumLength = AdConstants.NameMin,
        ErrorMessage = "Ad name must be between {2} and {1} characters.")]
    public string Name { get; set; } = null!;

    [Required]
    [StringLength(AdConstants.DescriptionMax,MinimumLength = AdConstants.DescriptionMin,
        ErrorMessage = "Description must be between {2} and {1} characters.")]
    public string Description { get; set; } = null!;

    [Required]
    //[DisplayName("Image URL")]
    public string ImageUrl { get; set; } = null!;

    [Required]
    public decimal Price { get; set; }

    [Required]
    public int CategoryId { get; set; }

    public IEnumerable<CategoryViewModel> Categories { get; set; }
        = new List<CategoryViewModel>();
}
