using System.Xml.Serialization;

namespace ProductShop.DTOs.Export;

[XmlType("Product")]
public class ExportProductDto
{
    public string name { get; set; }
    public decimal price { get; set; }

}
