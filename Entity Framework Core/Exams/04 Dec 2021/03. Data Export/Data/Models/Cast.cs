﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Theatre.Data.Models;
public class Cast
{
    [Key]
    public int Id { get; set; }

    [Required, MaxLength(30)]
    public string FullName { get; set; }

    [Required]
    public bool IsMainCharacter { get; set; }

    [Required, MaxLength(15)]
    public string PhoneNumber { get; set; }

    [Required]
    public int PlayId { get; set; }

    [Required, ForeignKey(nameof(PlayId))]
    public Play Play { get; set; }
}
