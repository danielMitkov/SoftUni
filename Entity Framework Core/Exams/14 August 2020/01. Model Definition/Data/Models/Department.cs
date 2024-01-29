using System.ComponentModel.DataAnnotations;

namespace SoftJail.Data.Models;
public class Department
{
    [Key]
    public int Id { get; set; }

    [MinLength(3), MaxLength(25)]
    public string Name { get; set; }

    public ICollection<Cell> Cells { get; set; }
}
