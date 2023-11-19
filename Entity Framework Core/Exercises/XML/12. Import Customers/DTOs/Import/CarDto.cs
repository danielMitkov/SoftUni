using System.Xml.Serialization;

namespace CarDealer.DTOs.Import;

[XmlType("Car")]
public class CarDto
{
    public string make { get; set; } = null!;

    public string model { get; set; } = null!;

    public long traveledDistance { get; set; }

    [XmlArray]
    public List<PartDto> parts { get; set; } = new();
}
