using System.Xml.Serialization;

namespace VaporStore.DataProcessor.ExportDto;

[XmlType("Game")]
public class ExportGameDto
{
    [XmlAttribute("title")]
    public string Title { get; set; }

    public string Genre { get; set; }

    public double Price { get; set; }
}
