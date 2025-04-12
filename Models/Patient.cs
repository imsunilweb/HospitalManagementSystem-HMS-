using HospitalManagementSystem_HMS_.IdentityModels;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem_HMS_.Models
{
    public class Patient
    {
        [Key]
        public int Patient_ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateOnly DOB { get; set; }

        public string Gender { get; set; }

        public string BloodGroup { get; set; }

        [EmailAddress]
        public string EmailID { get; set; } 

        public string Address { get; set; }

        public string MobileNo { get; set; }

        public HealthSchemeType HealthScheme { get; set; }  // ✅ Enum used here

    }
}
