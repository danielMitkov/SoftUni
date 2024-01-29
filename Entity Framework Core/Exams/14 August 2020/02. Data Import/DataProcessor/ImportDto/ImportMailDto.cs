using System.ComponentModel.DataAnnotations;

namespace SoftJail.DataProcessor.ImportDto;
public class ImportMailDto
{
    public string Description { get; set; }

    public string Sender { get; set; }

    [RegularExpression(@"^[0-9a-zA-Z ]+str\.$")]
    public string Address { get; set; }
}
