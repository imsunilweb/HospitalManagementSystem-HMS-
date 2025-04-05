using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem_HMS_.IdentityModels
{
    public class ApplicationUser : IdentityUser
    {
        [Required,StringLength(100, MinimumLength = 3, ErrorMessage = "Full Name must be between 3 and 100 characters.")]
        public string FullName { get; set; }

        [Required,RegularExpression("^(A|B|AB|O)[+-]$", ErrorMessage = "Invalid Blood Group format.")]
        public string BloodGroup { get; set; }

        [Required,DataType(DataType.Date)]
        public DateTime DOB { get; set; }

        [Required,RegularExpression("^(Male|Female|Other)$", ErrorMessage = "Gender must be Male, Female, or Other.")]
        public string Gender { get; set; }

        
        [Required,StringLength(255, ErrorMessage = "Address must not exceed 255 characters.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Health Scheme is required.")]
        public HealthSchemeType HealthScheme { get; set; }
    }
}
