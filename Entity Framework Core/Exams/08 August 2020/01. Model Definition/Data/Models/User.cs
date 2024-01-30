using System.ComponentModel.DataAnnotations;

namespace VaporStore.Data.Models;
public class User
{
    [Key]
    public int Id { get; set; }

    [MaxLength(20)]
    public string Username { get; set; }

    public string FullName { get; set; }

    public string Email { get; set; }

    public int Age { get; set; }

    public ICollection<Card> Cards { get; set; }
}
