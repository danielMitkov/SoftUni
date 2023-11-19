using System.Xml.Serialization;

namespace ProductShop.DTOs.Export;

[XmlType("User")]
public class ExportUserDto
{
    public string? firstName { get; set; }
    public string lastName { get; set; }
    public int? age { get; set; }
    public ExportSoldProductsDto SoldProducts { get; set; }
}
