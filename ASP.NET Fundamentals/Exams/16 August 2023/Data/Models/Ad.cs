using Microsoft.AspNetCore.Identity;
using SoftUniBazar.Data.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftUniBazar.Data.Models;

public class Ad
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(AdConstants.NameMax)]
    public string Name { get; set; } = null!;

    [Required]
    [MaxLength(AdConstants.DescriptionMax)]
    public string Description { get; set; } = null!;

    [Required]
    public decimal Price { get; set; }

    [Required]
    public string OwnerId { get; set; } = null!;

    [Required]
    public IdentityUser Owner { get; set; } = null!;

    [Required]
    public string ImageUrl { get; set; } = null!;

    [Required]
    public DateTime CreatedOn { get; set; }

    [Required]
    public int CategoryId { get; set; }

    [ForeignKey(nameof(CategoryId))]
    public Category Category { get; set; } = null!;
}
