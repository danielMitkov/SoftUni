using System.ComponentModel.DataAnnotations;

namespace SoftJail.DataProcessor.ImportDto;
public class ImportPrisonerDto
{
    [Required,MinLength(3), MaxLength(20)]
    public string FullName { get; set; }

    [Required,RegularExpression(@"^The [A-Z][a-z]+$")]
    public string Nickname { get; set; }

    [Range(18,65)]
    public int Age { get; set; }

    public DateTime IncarcerationDate { get; set; }

    public DateTime? ReleaseDate { get; set; }

    [Range(0,double.MaxValue)]
    public decimal? Bail { get; set; }

    public int? CellId { get; set; }

    public ICollection<ImportMailDto> Mails { get; set; }
}
