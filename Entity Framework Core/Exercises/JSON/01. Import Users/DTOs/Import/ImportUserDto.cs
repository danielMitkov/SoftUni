using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ProductShop.DTOs.Import;

public class ImportUserDto
{
    public string? FirstName { get; set; }

    public string LastName { get; set; } = null!;

    public int? Age { get; set; }
}
