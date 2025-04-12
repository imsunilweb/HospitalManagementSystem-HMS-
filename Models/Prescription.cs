using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagementSystem_HMS_.Models
{
    public class Prescription
    {
        [Key]
        public int PrescriptionId { get; set; }
        
        public int Appointment_ID { get; set; }  

        public string Medicine { get; set; }
        public string Remark { get; set; }
        public string Advice { get; set; }
        [ForeignKey("Appointment_ID")]
        public Appointment Appointment { get; set; }  // Navigation property to Appointment
    }
}
