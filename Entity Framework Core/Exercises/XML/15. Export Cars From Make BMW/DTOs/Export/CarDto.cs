using System.Xml.Serialization;

namespace CarDealer.DTOs.Export;

[XmlType("car")]
public class CarDto
{
    [XmlAttribute]
    public int id { get; set; }

    [XmlAttribute]
    public string model { get; set; } = null!;

    [XmlAttribute("traveled-distance")]
    public long TraveledDistance { get; set; }
}
