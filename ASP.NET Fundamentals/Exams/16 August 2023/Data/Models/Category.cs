using System.ComponentModel.DataAnnotations;
using SoftUniBazar.Data.Constants;

namespace SoftUniBazar.Data.Models;

public class Category
{
    public int Id { get; set; }

    [MaxLength(CategoryConstants.NameMax)]
    public string Name { get; set; } = null!;

    public virtual ICollection<Ad> Ads { get; set; } = new List<Ad>();
}
