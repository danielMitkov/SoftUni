using System.Xml.Serialization;

namespace Footballers.DataProcessor.ExportDto;

[XmlType("Coach")]
public class ExportCoachDto
{
    [XmlAttribute]
    public int FootballersCount { get; set; }

    public string CoachName { get; set; }

    [XmlArray]
    public ExportFootballerDto[] Footballers { get; set; }
}
