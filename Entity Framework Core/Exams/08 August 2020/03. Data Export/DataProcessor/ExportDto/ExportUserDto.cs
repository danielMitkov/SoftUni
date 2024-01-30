using System.Xml.Serialization;

namespace VaporStore.DataProcessor.ExportDto;

[XmlType("User")]
public class ExportUserDto
{
    [XmlAttribute("username")]
    public string Username { get; set; }

    [XmlArray]
    public ExportPurchaseDto[] Purchases { get; set; }

    public double TotalSpent { get; set; }
}
