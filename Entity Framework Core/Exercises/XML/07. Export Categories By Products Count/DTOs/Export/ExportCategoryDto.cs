using System.Xml.Serialization;

namespace ProductShop.DTOs.Export;

[XmlType("Category")]
public class ExportCategoryDto
{
    public string name { get; set; } = null!;

    public int count { get; set; }

    public decimal averagePrice { get; set; }

    public decimal totalRevenue { get; set; }
}
