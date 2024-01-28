using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P01_HospitalDatabase.Data.Models
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }

        [MaxLength(50)]
        public string FirstName { get; set; } = null!;

        [MaxLength(50)]
        public string LastName { get; set; } = null!;

        [MaxLength(250)]
        public string Address { get; set; } = null!;

        [Column(TypeName = "VARCHAR(80)")]
        public string Email { get; set; } = null!;

        public bool HasInsurance { get; set; }

        public ICollection<Diagnose> Diagnoses { get; set; } = new HashSet<Diagnose>();

        public ICollection<Visitation> Visitations { get; set; } = new HashSet<Visitation>();

        public ICollection<PatientMedicament> Prescriptions { get; set; } = new HashSet<PatientMedicament>();
    }
}
