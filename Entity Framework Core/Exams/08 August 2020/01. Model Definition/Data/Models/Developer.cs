﻿using System.ComponentModel.DataAnnotations;

namespace VaporStore.Data.Models;
public class Developer
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; }

    public ICollection<Game> Games { get; set; }
}
