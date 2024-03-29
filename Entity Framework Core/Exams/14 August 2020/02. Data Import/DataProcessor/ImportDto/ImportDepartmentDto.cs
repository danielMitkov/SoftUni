﻿using System.ComponentModel.DataAnnotations;

namespace SoftJail.DataProcessor.ImportDto;
public class ImportDepartmentDto
{
    [MinLength(3), MaxLength(25)]
    public string Name { get; set; }
    public ImportCellDto[] Cells { get; set; }
}
