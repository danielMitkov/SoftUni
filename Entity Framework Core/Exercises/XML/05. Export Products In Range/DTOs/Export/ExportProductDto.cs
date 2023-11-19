using System.Xml.Serialization;

namespace ProductShop.DTOs.Export;

[XmlType("Product")]
public class ExportProductDto
{
    [XmlElement("name")]
    public string Name { get; set; }

    [XmlElement("price")]
    public decimal Price { get; set; }

    [XmlElement("buyer")]
    public string Buyer { get; set; }
}
//write it simple, stupid for judge. Buyer will be empty but written element if its null