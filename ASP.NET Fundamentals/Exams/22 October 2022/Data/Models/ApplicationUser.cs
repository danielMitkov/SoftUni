using Microsoft.AspNetCore.Identity;

namespace Library.Data.Models;

public class ApplicationUser:IdentityUser
{
    public ICollection<Book> Books { get; set; } = new List<Book>();
}
