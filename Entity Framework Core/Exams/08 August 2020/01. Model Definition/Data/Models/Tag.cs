﻿using System.ComponentModel.DataAnnotations;

namespace VaporStore.Data.Models;
public class Tag
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; }

    public ICollection<GameTag> GameTags { get; set; }
}
