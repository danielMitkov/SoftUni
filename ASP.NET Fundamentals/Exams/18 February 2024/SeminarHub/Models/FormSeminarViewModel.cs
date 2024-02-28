using SeminarHub.Data.Constants;
using System.ComponentModel.DataAnnotations;

namespace SeminarHub.Models;

public class FormSeminarViewModel
{
    public int Id { get; set; }

    [Required]
    [StringLength(SeminarConstants.TopicMaxLength,
        MinimumLength = SeminarConstants.TopicMinLength,
        ErrorMessage = "Topic name must be between {2} and {1} characters long!")]
    public string Topic { get; set; } = null!;

    [Required]
    [StringLength(SeminarConstants.LecturerMaxLength,
        MinimumLength = SeminarConstants.LecturerMinLength,
        ErrorMessage = "Lecturer name must be between {2} and {1} characters long!")]
    public string Lecturer { get; set; } = null!;

    [Required]
    [StringLength(SeminarConstants.DetailsMaxLength,
        MinimumLength = SeminarConstants.DetailsMinLength,
        ErrorMessage = "Details must be between {2} and {1} characters long!")]
    public string Details { get; set; } = null!;

    [Required]
    public string DateAndTime { get; set; } = null!;

    [Required]
    [Range(SeminarConstants.DurationMinValue,
        SeminarConstants.DurationMaxValue,
        ErrorMessage = "Duration must be between {2} and {1}")]
    public int Duration { get; set; }

    [Required]
    public int CategoryId { get; set; }

    public IEnumerable<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();
}
