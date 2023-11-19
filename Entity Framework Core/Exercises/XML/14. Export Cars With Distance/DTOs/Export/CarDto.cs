using System.Xml.Serialization;

namespace CarDealer.DTOs.Export;

[XmlType("car")]
public class CarDto
{
    public string make { get; set; } = null!;

    public string model { get; set; } = null!;

    [XmlElement("traveled-distance")]
    public long TraveledDistance { get; set; }
}
