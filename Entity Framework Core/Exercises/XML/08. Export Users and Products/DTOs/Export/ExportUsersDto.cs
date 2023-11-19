using System.Xml.Serialization;

namespace ProductShop.DTOs.Export;

[XmlType("Users")]
public class ExportUsersDto
{
    public int count { get; set; }

    [XmlArray]
    public ExportUserDto[] users { get; set; }
}
