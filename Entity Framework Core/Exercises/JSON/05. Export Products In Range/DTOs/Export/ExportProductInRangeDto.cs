using Newtonsoft.Json;

namespace ProductShop.DTOs.Export;

public class ExportProductInRangeDto
{
    [JsonProperty("name")]
    public string Name { get; set; } = null!;

    [JsonProperty("price")]
    public decimal Price { get; set; }

    [JsonIgnore]
    public string? SellerFirstName { get; set; }

    [JsonIgnore]
    public string SellerLastName { get; set; } = null!;

    [JsonProperty("seller")]
    public string Seller => SellerFirstName + " " + SellerLastName;
}
