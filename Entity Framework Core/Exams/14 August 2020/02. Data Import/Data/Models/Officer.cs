﻿using SoftJail.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftJail.Data.Models;

public class Officer
{
    [Key]
    public int Id { get; set; }

    [MaxLength(30)]
    public string FullName { get; set; }

    public decimal Salary { get; set; }

    public Position Position { get; set; }

    public Weapon Weapon { get; set; }

    public int DepartmentId { get; set; }

    [ForeignKey(nameof(DepartmentId))]
    public Department Department { get; set; }

    public ICollection<OfficerPrisoner> OfficerPrisoners { get; set; }
}
