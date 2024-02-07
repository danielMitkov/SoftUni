using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Trucks.DataProcessor.ImportDto;

[XmlType("Truck")]
public class ImportTruckDto
{
    [Required,RegularExpression(@"^[A-Z]{2}[0-9]{4}[A-Z]{2}$")]
    public string RegistrationNumber { get; set; }

    [Required, MinLength(17), MaxLength(17)]
    public string VinNumber { get; set; }

    [Required, Range(950,1420)]
    public int TankCapacity { get; set; }

    [Required, Range(5000,29000)]
    public int CargoCapacity { get; set; }

    [Required]
    public string CategoryType { get; set; }

    [Required]
    public string MakeType { get; set; }
}
