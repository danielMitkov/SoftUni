using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace VaporStore.DataProcessor.ImportDto;
public class ImportGameDto
{
    [Required]
    public string Name { get; set; }

    [Required, Range(0,double.MaxValue)]
    public decimal Price { get; set; }

    [Required]
    public DateTime ReleaseDate { get; set; }

    [Required, JsonProperty("Developer")]
    public string DeveloperName { get; set; }

    [Required]
    public string Genre { get; set; }

    [Required]
    public string[] Tags { get; set; }
}
