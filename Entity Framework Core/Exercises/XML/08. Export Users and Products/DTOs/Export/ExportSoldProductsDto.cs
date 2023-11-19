using System.Xml.Serialization;

namespace ProductShop.DTOs.Export;

[XmlType("SoldProducts")]
public class ExportSoldProductsDto
{
    public int count { get { return products.Length; } set { } }

    [XmlArray]
    public ExportProductDto[] products { get; set; }
}
