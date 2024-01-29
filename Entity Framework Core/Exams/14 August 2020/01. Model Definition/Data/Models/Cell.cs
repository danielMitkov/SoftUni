using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftJail.Data.Models;
public class Cell
{
    [Key]
    public int Id { get; set; }

    [MinLength(1), MaxLength(1000)]
    public int CellNumber { get; set; }

    public bool HasWindow { get; set; }

    public int DepartmentId { get; set; }

    [ForeignKey(nameof(DepartmentId))]
    public Department Department { get; set; }

    public ICollection<Prisoner> Prisoners { get; set; }
}
