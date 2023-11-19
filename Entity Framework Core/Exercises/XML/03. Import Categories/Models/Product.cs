namespace ProductShop.Models;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Product
{
    public Product()
    {
        this.CategoryProducts = new List<CategoryProduct>();
    }
    [Key]
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public int SellerId { get; set; }

    [ForeignKey(nameof(SellerId))]
    public User Seller { get; set; } = null!;

    public int? BuyerId { get; set; }

    [ForeignKey(nameof(BuyerId))]
    public User? Buyer { get; set; } = null!;

    public ICollection<CategoryProduct> CategoryProducts { get; set; }
}
