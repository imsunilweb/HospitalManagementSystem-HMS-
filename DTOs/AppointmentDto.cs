using HospitalManagementSystem_HMS_.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagementSystem_HMS_.DTOs
{
    public class AppointmentDto
    {
        public int Appointment_ID { get; set; }
        public int Patient_ID { get; set; }

        public int Doctor_ID { get; set; }
        [Required(ErrorMessage = "Appointment date is required")]
        public DateOnly AppointmentDate { get; set; }
        [Required(ErrorMessage = "Appointment time is required")]
        public TimeOnly AppointmentTime { get; set; }
        [Required(ErrorMessage ="Consultant fee is required")]
        public int ConsultantFee { get; set; }

        public AppointmentStatus Status { get; set; } = AppointmentStatus.Confirmed;
    }
}
