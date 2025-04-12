using HospitalManagementSystem_HMS_.IdentityModels;
using HospitalManagementSystem_HMS_.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem_HMS_.Data_Set
{
    public class HospitalDbContext : IdentityDbContext<ApplicationUser>
    {
        public HospitalDbContext(DbContextOptions<HospitalDbContext> options) : base(options)
        {
        }
        public DbSet<ApplicationUser> ApplicationUserSet { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
    }
}
