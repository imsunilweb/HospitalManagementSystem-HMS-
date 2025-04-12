using HospitalManagementSystem_HMS_.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class Appointment
{
    [Key]
    public int Appointment_ID { get; set; }

    [Required]
    public int Patient_ID { get; set; }

    [ForeignKey("Patient_ID")]
    public Patient Patient { get; set; }

    [Required]
    public int Doctor_ID { get; set; }

    [ForeignKey("Doctor_ID")]
    public Doctor Doctor { get; set; }

    public DateOnly Date { get; set; }

    public TimeOnly Time { get; set; }
    public int ConsultantFee { get; set; }

    public AppointmentStatus Status { get; set; }


}
public enum AppointmentStatus
{
    Confirmed,
    Completed,
    Cancelled,
    Missed
}
