using System.Xml.Serialization;

namespace CarDealer.DTOs.Import;

[XmlType("Customer")]
public class CustomerDto
{
    public string name { get; set; } = null!;

    public DateTime birthDate { get; set; }

    public bool isYoungDriver { get; set; }
}
