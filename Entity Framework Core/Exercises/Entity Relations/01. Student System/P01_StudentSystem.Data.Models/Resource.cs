using P01_StudentSystem.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P01_StudentSystem.Data.Models;

public class Resource
{
    [Key]
    public int ResourceId { get; set; }

    [MaxLength(50)]
    public string Name { get; set; }

    [Column(TypeName = "VARCHAR(2000)")]
    public string Url { get; set; }

    public ResourceType ResourceType { get; set; }

    public int CourseId { get; set; }

    [ForeignKey(nameof(CourseId))]
    public Course Course { get; set; }
}
