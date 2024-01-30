using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using VaporStore.Data.Models.Enums;

namespace VaporStore.DataProcessor.ImportDto;

[XmlType("Purchase")]
public class ImportPurchaseDto
{
    [Required, XmlAttribute("title")]
    public string GameTitle { get; set; }

    [Required/*, EnumDataType(typeof(PurchaseType))*/]
    public string Type { get; set; }

    [Required, XmlElement("Key"), RegularExpression(@"^[A-Z0-9]{4}-[A-Z0-9]{4}-[A-Z0-9]{4}$")]
    public string ProductKey { get; set; }

    [Required, XmlElement("Card"), RegularExpression(@"^[0-9]{4} [0-9]{4} [0-9]{4} [0-9]{4}$")]
    public string CardNumber { get; set; }

    [Required]
    public string Date { get; set; }
}
