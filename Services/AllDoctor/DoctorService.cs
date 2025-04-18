using AutoMapper;
using HospitalManagementSystem_HMS_.Data_Set;
using HospitalManagementSystem_HMS_.DTOs;
using HospitalManagementSystem_HMS_.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem_HMS_.Services.AllDoctor
{
    public class DoctorService : IDoctorService
    {
        private readonly HospitalDbContext _context;
        private readonly IMapper _mapper;

        public DoctorService(HospitalDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<DoctorDto>> GetAllDoctorsAsync()
        {
            var doctors = await _context.Doctors.ToListAsync();
            return _mapper.Map<List<DoctorDto>>(doctors);
        }

        public async Task<DoctorDto> GetDoctorByIdAsync(int doctorId)
        {
            var doctor = await _context.Doctors.FirstOrDefaultAsync(d => d.Doctor_ID == doctorId);
            return doctor != null ? _mapper.Map<DoctorDto>(doctor) : null;
        }

        public async Task AddDoctorAsync(DoctorDto dto)
        {
            var doctor = _mapper.Map<Doctor>(dto);
            _context.Doctors.Add(doctor);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateDoctorAsync(DoctorDto dto)
        {
            var doctor = await _context.Doctors.FirstOrDefaultAsync(d => d.Doctor_ID == dto.Doctor_ID);
            if (doctor != null)
            {
                _mapper.Map(dto, doctor);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteDoctorAsync(int doctorId)
        {
            var doctor = await _context.Doctors.FirstOrDefaultAsync(d => d.Doctor_ID == doctorId);
            if (doctor != null)
            {
                _context.Doctors.Remove(doctor);
                await _context.SaveChangesAsync();
            }
        }

        // ✅ Naya method: Get all patients for a doctor
        public async Task<List<PatientDto>> GetPatientsForDoctorAsync(int doctorId)
        {
            var patients = await _context.Appointments
                .Where(a => a.Doctor_ID == doctorId)
                .Join(_context.Patients,
                      a => a.Patient_ID,
                      p => p.Patient_ID,
                      (a, p) => p)
                .ToListAsync();

            return _mapper.Map<List<PatientDto>>(patients);
        }
    }
}
