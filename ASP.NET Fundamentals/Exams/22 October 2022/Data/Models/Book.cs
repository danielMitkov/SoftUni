using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Library.Data.Constants;

namespace Library.Data.Models;

public class Book
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(BookConstants.TitleMax)]
    public string Title { get; set; } = null!;

    [Required]
    [MaxLength(BookConstants.AuthorMax)]
    public string Author { get; set; } = null!;

    [Required]
    [MaxLength(BookConstants.DescriptionMax)]
    public string Description { get; set; } = null!;

    [Required]
    public string ImageUrl { get; set; } = null!;

    [Required]
    public decimal Rating { get; set; }

    [Required]
    public int CategoryId { get; set; }

    [Required]
    [ForeignKey(nameof(CategoryId))]
    public Category Category { get; set; } = null!;

    public ICollection<ApplicationUserBook> ApplicationUsersBooks { get; set; } = new List<ApplicationUserBook>();
}
