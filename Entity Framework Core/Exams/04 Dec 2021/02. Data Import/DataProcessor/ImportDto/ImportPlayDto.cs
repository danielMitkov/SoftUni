﻿using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Theatre.DataProcessor.ImportDto;

[XmlType("Play")]
public class ImportPlayDto
{
    [Required, MinLength(4), MaxLength(50)]
    public string Title { get; set; }

    [Required]
    public string Duration { get; set; }

    [Required, XmlElement("Raiting"), Range(0.00,10.00)]//misspelled "ra'i'ting"
    public float Rating { get; set; }

    [Required]
    public string Genre { get; set; }

    [Required, MaxLength(700)]
    public string Description { get; set; }

    [Required, MinLength(4), MaxLength(30)]
    public string Screenwriter { get; set; }
}
