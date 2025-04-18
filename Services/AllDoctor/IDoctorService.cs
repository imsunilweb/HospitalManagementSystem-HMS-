using HospitalManagementSystem_HMS_.DTOs;

namespace HospitalManagementSystem_HMS_.Services.AllDoctor
{
    public interface IDoctorService
    {
        Task<List<DoctorDto>> GetAllDoctorsAsync();
        Task<DoctorDto> GetDoctorByIdAsync(int doctorId);
        Task AddDoctorAsync(DoctorDto dto);
        Task UpdateDoctorAsync(DoctorDto dto);
        Task DeleteDoctorAsync(int doctorId);

        // ✅ NEW method for fetching patients under a doctor
        Task<List<PatientDto>> GetPatientsForDoctorAsync(int doctorId);

    }
}
