using System.Xml.Serialization;

namespace CarDealer.DTOs.Import;

[XmlType("Supplier")]
public class SupplierDto
{
    public string name { get; set; } = null!;

    public bool isImporter { get; set; }
}
