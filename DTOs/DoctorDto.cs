using HospitalManagementSystem_HMS_.Models;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem_HMS_.DTOs
{
    public class DoctorDto
    {
        public int Doctor_ID { get; set; }
        [Required(ErrorMessage = "Doctor name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Age is required")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Gender is required")]
        [RegularExpression("^(?i:male|female|other)$\r\n", ErrorMessage = "Please enter the valid gender")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Specialization is required")]
        public string Specialization { get; set; }
        [Required(ErrorMessage = "Experience is required")]
        public string Experience { get; set; }
        [Required(ErrorMessage = "Language is required")]
        public languages Language { get; set; }
        [Required(ErrorMessage = "Mobile No is required")]
        public string MobileNo { get; set; }
        [Required(ErrorMessage = "Email ID is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string EmailID { get; set; }
        [Required(ErrorMessage = "Schedule is required")]
        public TimeSpan Schedule { get; set; }
    }
}
