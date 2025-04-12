using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem_HMS_.Models
{
    public class Admin
    {
        [Key]
        public int Admin_ID { get; set; }  // Unique Admin ID

        [Required]
        public string AdminName { get; set; }

        [Required]
        public DateOnly DOB { get; set; }  // You can use DateTime if needed

        [Required]
        public string Gender { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string MobileNo { get; set; }

        public string Address { get; set; }
    }
}
