using HospitalManagementSystem_HMS_.IdentityModels;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem_HMS_.DTOs
{
    public class PatientDto
    {
        public string Patient_ID { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Date of Birth is required")]
        public DateOnly DOB { get; set; }
        [Required(ErrorMessage = "Gender is required")]
        [RegularExpression("^(?i:male|female|other)$\r\n", ErrorMessage = "Please enter the valid gender")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Blood group is required")]
        public string BloodGroup { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string EmailID { get; set; }
        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Mobile Number is required")]
        public int MobileNo { get; set; }
         
        public HealthSchemeType HealthScheme { get; set; }  // ✅ Enum here too

    }
}
