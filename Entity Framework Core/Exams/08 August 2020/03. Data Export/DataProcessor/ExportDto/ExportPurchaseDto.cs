using System.Xml.Serialization;

namespace VaporStore.DataProcessor.ExportDto;

[XmlType("Purchase")]
public class ExportPurchaseDto
{
    public string Card { get; set; }

    public string Cvc { get; set; }

    public string Date { get; set; }

    public ExportGameDto Game { get; set; }
}
