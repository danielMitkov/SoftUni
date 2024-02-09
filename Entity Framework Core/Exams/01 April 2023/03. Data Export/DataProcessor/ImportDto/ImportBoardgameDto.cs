using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Boardgames.DataProcessor.ImportDto;

[XmlType("Boardgame")]
public class ImportBoardgameDto
{
    [Required, MinLength(10), MaxLength(20)]
    public string Name { get; set; }

    [Required, Range(1.00,10.00)]
    public double Rating { get; set; }

    [Required, Range(2018,2023)]
    public int YearPublished { get; set; }

    [Required, Range(0,4)]
    public int CategoryType { get; set; }

    [Required]
    public string Mechanics { get; set; }
}
