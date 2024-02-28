using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using SeminarHub.Data.Constants;

namespace SeminarHub.Data.Models;

public class Seminar
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(SeminarConstants.TopicMaxLength)]
    public string Topic { get; set; } = null!;

    [Required]
    [MaxLength(SeminarConstants.LecturerMaxLength)]
    public string Lecturer { get; set; } = null!;

    [Required]
    [MaxLength(SeminarConstants.DetailsMaxLength)]
    public string Details { get; set; } = null!;

    [Required]
    public string OrganizerId { get; set; } = null!;

    [Required]
    [ForeignKey(nameof(OrganizerId))]
    public IdentityUser Organizer { get; set; } = null!;

    [Required]
    public DateTime DateAndTime { get; set; }

    [Required]
    public int Duration { get; set; }

    [Required]
    public int CategoryId { get; set; }

    [Required]
    [ForeignKey(nameof(CategoryId))]
    public Category Category { get; set; } = null!;

    public ICollection<SeminarParticipant> SeminarsParticipants { get; set; } = new List<SeminarParticipant>();
}
