using System.ComponentModel.DataAnnotations.Schema;

namespace P01_HospitalDatabase.Data.Models
{
    public class PatientMedicament
    {
        public int PatientId { get; set; }

        [ForeignKey(nameof(PatientId))]
        public Patient Patient { get; set; } = null!;

        public int MedicamentId { get; set; }

        [ForeignKey(nameof(MedicamentId))]
        public Medicament Medicament { get; set; } = null!;
    }
}
