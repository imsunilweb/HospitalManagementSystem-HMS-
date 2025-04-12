using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem_HMS_.DTOs
{
    public class AdminDto
    {
        
        public int Admin_ID { get; set; }
        [Required(ErrorMessage = "Admin Name is required")]
        public string AdminName { get; set; }
        [Required(ErrorMessage = "Date of Birth is required")]
        public DateOnly DOB { get; set; }
        [Required(ErrorMessage ="Gender is required")]
        [RegularExpression("^(?i:male|female|other)$\r\n",ErrorMessage ="Please enter the valid gender")]
        public string Gender { get; set; }
        [EmailAddress, Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Mobile Number is required")]
        public string MobileNo { get; set; }
        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }
    }
}
