using System.Xml.Serialization;
using Theatre.Data.Models.Enums;

namespace Theatre.DataProcessor.ExportDto;

[XmlType("Play")]
public class ExportPlayDto
{
    [XmlAttribute]
    public string Title { get; set; }

    [XmlAttribute]
    public string Duration { get; set; }

    [XmlAttribute]
    public string Rating { get; set; }

    [XmlAttribute]
    public string Genre { get; set; }

    [XmlArray]
    public ExportActorDto[] Actors { get; set; }
}
