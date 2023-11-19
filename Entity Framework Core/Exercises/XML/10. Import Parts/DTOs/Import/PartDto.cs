using System.Xml.Serialization;

namespace CarDealer.DTOs.Import;

[XmlType("Part")]
public class PartDto
{
    public string name { get; set; } = null!;

    public decimal price { get; set; }

    public int quantity { get; set; }

    public int supplierId { get; set; }
}
