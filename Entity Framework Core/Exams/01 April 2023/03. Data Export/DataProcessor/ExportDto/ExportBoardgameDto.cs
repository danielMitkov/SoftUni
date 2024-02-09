using System.Xml.Serialization;

namespace Boardgames.DataProcessor.ExportDto;

[XmlType("Boardgame")]
public class ExportBoardgameDto
{
    public string BoardgameName { get; set; }

    public int BoardgameYearPublished { get; set; }
}
