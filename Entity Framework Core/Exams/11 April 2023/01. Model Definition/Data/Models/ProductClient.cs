using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Invoices.Data.Models;
public class ProductClient
{
    [Required]
    public int ProductId { get; set; }

    [Required, ForeignKey(nameof(ProductId))]
    public Product Product { get; set; }

    [Required]
    public int ClientId { get; set; }

    [Required, ForeignKey(nameof(ClientId))]
    public Client Client { get; set; }
}
