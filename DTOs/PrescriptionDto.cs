using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem_HMS_.DTOs
{
    public class PrescriptionDto
    {
        public int Appointment_ID { get; set; }  // Unique Prescription ID
        [Required(ErrorMessage = "Medicine is required")]
        public string Medicine { get; set; }
        [Required(ErrorMessage = "Remark is required")]
        public string Remark { get; set; }
        [Required(ErrorMessage = "Advice is required")]
        public string Advice { get; set; }

        public Appointment Appointment { get; set; }  // Navigation property to Appointment
    }
}
