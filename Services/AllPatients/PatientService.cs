using AutoMapper;
using HospitalManagementSystem_HMS_.Data_Set;
using HospitalManagementSystem_HMS_.DTOs;
using HospitalManagementSystem_HMS_.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem_HMS_.Services.AllPatients
{
    public class PatientService : IPatientService
    {
        private readonly HospitalDbContext _context;
        private readonly IMapper _mapper;

        public PatientService(HospitalDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<PatientDto>> GetAllPatientsAsync()
        {
            var patients = await _context.Patients.ToListAsync();
            return _mapper.Map<List<PatientDto>>(patients);
        }

        public async Task<PatientDto> GetPatientByIdAsync(string id)
        {
            var patient = await _context.Patients.FindAsync(id);
            return _mapper.Map<PatientDto>(patient);
        }

        public async Task AddPatientAsync(PatientDto dto)
        {
            var patient = _mapper.Map<Patient>(dto);
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();
        }
    }

}
