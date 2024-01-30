using System.ComponentModel.DataAnnotations;

namespace VaporStore.DataProcessor.ImportDto;
public class ImportUserDto
{
    [Required, RegularExpression(@"^[A-Z][a-z]+ [A-Z][a-z]+$")]
    public string FullName { get; set; }

    [Required, MinLength(3), MaxLength(20)]
    public string Username { get; set; }

    [Required]
    public string Email { get; set; }

    [Required, Range(3,103)]
    public int Age { get; set; }

    [Required]
    public ICollection<ImportCardDto> Cards { get; set; }
}
