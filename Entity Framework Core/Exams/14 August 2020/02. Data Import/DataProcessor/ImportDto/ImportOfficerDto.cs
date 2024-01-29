using SoftJail.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace SoftJail.DataProcessor.ImportDto;

[XmlType("Officer")]
public class ImportOfficerDto
{
    [Required, MinLength(3), MaxLength(30), XmlElement("Name")]
    public string FullName { get; set; }

    [Required, Range(0,double.MaxValue), XmlElement("Money")]
    public decimal Salary { get; set; }

    [Required]
    public string Position { get; set; }

    [Required]
    public string Weapon { get; set; }

    [Required]
    public int DepartmentId { get; set; }

    [XmlArray]
    public ImportOfficerPrisonerDto[] Prisoners { get; set; }
}
