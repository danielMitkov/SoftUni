﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace P01_HospitalDatabase.Data.Models
{
    public class Doctor
    {
        [Key]
        public int DoctorId { get; set; }

        [MaxLength(100)]
        public string Name { get; set; } = null!;

        [MaxLength(100)]
        public string Specialty { get; set; } = null!;

        public virtual ICollection<Visitation> Visitations { get; set; } = new HashSet<Visitation>();
    }
}
