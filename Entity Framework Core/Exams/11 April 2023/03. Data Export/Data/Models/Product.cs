﻿using Invoices.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Invoices.Data.Models;
public class Product
{
    [Key]
    public int Id { get; set; }

    [Required, MaxLength(30)]
    public string Name { get; set; }

    [Required]
    public decimal Price { get; set; }

    [Required]
    public CategoryType CategoryType { get; set; }

    public ICollection<ProductClient> ProductsClients { get; set; } = new HashSet<ProductClient>();
}
