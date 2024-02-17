using System.ComponentModel.DataAnnotations;
using Library.Data.Constants;

namespace Library.Data.Models;

public class Category
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(CategoryConstants.NameMax)]
    public string Name { get; set; } = null!;

    public ICollection<Book> Books { get; set; } = new List<Book>();
}
