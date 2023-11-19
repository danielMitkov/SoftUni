using System.Xml.Serialization;

namespace CarDealer.DTOs.Import;

[XmlType("Sale")]
public class SaleDto
{
    public decimal discount { get; set; }

    public int carId { get; set; }

    public int customerId { get; set; }
}
