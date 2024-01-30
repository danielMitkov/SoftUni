using System.ComponentModel.DataAnnotations;

namespace VaporStore.DataProcessor.ImportDto;
public class ImportCardDto
{
    [Required, RegularExpression(@"^[0-9]{4} [0-9]{4} [0-9]{4} [0-9]{4}$")]
    public string Number { get; set; }

    [Required, RegularExpression(@"^[0-9]{3}$")]
    public string Cvc { get; set; }

    [Required/*, EnumDataType(typeof(CardType))*/]// cannot test if this attribute works because all types are valid in the json
    public string Type { get; set; }
}
