﻿using System.Xml.Serialization;

namespace Artillery.DataProcessor.ExportDto;

[XmlType("Country")]
public class ExportCountryDto
{
    [XmlAttribute("Country")]
    public string CountryName { get; set; }

    [XmlAttribute]
    public int ArmySize { get; set; }
}
