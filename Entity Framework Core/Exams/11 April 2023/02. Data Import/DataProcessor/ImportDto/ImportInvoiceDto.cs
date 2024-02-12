using System.ComponentModel.DataAnnotations;

namespace Invoices.DataProcessor.ImportDto;
public class ImportInvoiceDto
{
    [Required, Range(1_000_000_000,1_500_000_000)]
    public int Number { get; set; }

    [Required]
    public string IssueDate { get; set; }

    [Required]
    public string DueDate { get; set; }

    [Required, /*Range(1,double.MaxValue)*/]
    public decimal Amount { get; set; }

    [Required, Range(0,2)]
    public int CurrencyType { get; set; }

    [Required]
    public int ClientId { get; set; }
}
