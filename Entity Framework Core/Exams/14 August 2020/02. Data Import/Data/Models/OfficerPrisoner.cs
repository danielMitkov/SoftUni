﻿using System.ComponentModel.DataAnnotations.Schema;

namespace SoftJail.Data.Models;
public class OfficerPrisoner
{
    public int PrisonerId { get; set; }

    [ForeignKey(nameof(PrisonerId))]
    public Prisoner Prisoner { get; set; }

    public int OfficerId { get; set; }

    [ForeignKey(nameof(OfficerId))]
    public Officer Officer { get; set; }
}
