using Library.Data.Constants;
using Library.Models.Category;
using System.ComponentModel.DataAnnotations;

namespace Library.Models.Book;

public class FormBookViewModel
{
    [Required]
    [MinLength(BookConstants.TitleMin)]
    [MaxLength(BookConstants.TitleMax)]
    public string Title { get; set; } = null!;

    [Required]
    [MinLength(BookConstants.AuthorMin)]
    [MaxLength(BookConstants.AuthorMax)]
    public string Author { get; set; } = null!;

    [Required]
    [MinLength(BookConstants.DescriptionMin)]
    [MaxLength(BookConstants.DescriptionMax)]
    public string Description { get; set; } = null!;

    [Required]
    public string ImageUrl { get; set; } = null!;

    [Required]
    [Range(BookConstants.RatingMin,BookConstants.RatingMax)]
    public decimal Rating { get; set; }

    [Required]
    public int CategoryId { get; set; }

    public ICollection<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();
}
