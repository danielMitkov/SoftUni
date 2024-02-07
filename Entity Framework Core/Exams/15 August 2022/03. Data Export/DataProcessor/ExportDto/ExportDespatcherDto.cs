using System.Xml.Serialization;

namespace Trucks.DataProcessor.ExportDto;

[XmlType("Despatcher")]
public class ExportDespatcherDto
{
    [XmlAttribute]
    public int TrucksCount { get; set; }

    public string DespatcherName { get; set; }

    [XmlArray]
    public ExportTruckDto[] Trucks { get; set; }
}
