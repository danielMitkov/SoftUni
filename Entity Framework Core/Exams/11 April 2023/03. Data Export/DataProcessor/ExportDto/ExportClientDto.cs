using System.Xml.Serialization;

namespace Invoices.DataProcessor.ExportDto;

[XmlType("Client")]
public class ExportClientDto
{
    [XmlAttribute]
    public int InvoicesCount { get; set; }

    public string ClientName { get; set; }

    public string VatNumber { get; set; }

    [XmlArray]
    public ExportInvoiceDto[] Invoices { get; set; }
}
