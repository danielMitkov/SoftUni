using System.ComponentModel.DataAnnotations;
using SeminarHub.Data.Constants;

namespace SeminarHub.Data.Models;

public class Category
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(CategoryConstants.NameMaxLength)]
    public string Name { get; set; } = null!;

    public ICollection<Seminar> Seminars { get; set; } = new List<Seminar>();
}
