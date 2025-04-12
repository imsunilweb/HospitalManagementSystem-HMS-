using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem_HMS_.Models
{
    public class Doctor
    {
        [Key]
        public int Doctor_ID { get; set; } // Primary Key
        public string Name { get; set; } // Name of the doctor

        [Range(20, 80)]
        public int Age { get; set; }

        [Required]
        public string Gender { get; set; }

        [MaxLength(50)]
        public string Specialization { get; set; }

        [MaxLength(50)]
        public string Experience { get; set; } // Can also be int if numeric

        [MaxLength(50)]
        public languages Language { get; set; }

        public string MobileNo { get; set; }

        [EmailAddress]
        public string EmailID { get; set; }

        [MaxLength(50)]
        public TimeSpan Schedule { get; set; }

        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
    public enum languages
    {
        Hindi,
        English,
        Marathi,
        Gujarati,
        Bengali,
        Kannada,
        Telugu,
        Tamil,
        Malayalam,
        Punjabi
    }
}

