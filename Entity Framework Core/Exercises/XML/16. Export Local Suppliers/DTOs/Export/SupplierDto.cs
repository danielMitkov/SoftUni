using System.Xml.Serialization;

namespace CarDealer.DTOs.Export;

[XmlType("supplier")]
public class SupplierDto
{
    [XmlAttribute]
    public int id { get; set; }

    [XmlAttribute]
    public string name { get; set; } = null!;

    [XmlAttribute("parts-count")]
    public int PartsCount { get; set; }
}
