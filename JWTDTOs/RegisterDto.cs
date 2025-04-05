using HospitalManagementSystem_HMS_.IdentityModels;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem_HMS_.JWTDTOs
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "Full Name is required.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Full Name must be between 3 and 100 characters.")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required.")]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Blood Group is required.")]
        [RegularExpression("^(A|B|AB|O)[+-]$", ErrorMessage = "Invalid Blood Group format.")]
        public string BloodGroup { get; set; }

        [Required(ErrorMessage = "Date of Birth is required.")]
        public DateTime DOB { get; set; }

        [Required(ErrorMessage = "Gender is required.")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Role is required.")]
        public string Role { get; set; }  // 🔥 Role Based

        [Required(ErrorMessage = "Address is required.")]
        [StringLength(255, ErrorMessage = "Address must not exceed 255 characters.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Health Scheme is required.")]
        public HealthSchemeType HealthScheme { get; set; }
    }
}
