using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Footballers.DataProcessor.ImportDto;

[XmlType("Coach")]
public class ImportCoachDto
{
    [Required, MinLength(2), MaxLength(40)]
    public string Name { get; set; }

    [Required, MinLength(1)]
    public string Nationality { get; set; }

    [XmlArray]
    public ImportFootballerDto[] Footballers { get; set; }
}
