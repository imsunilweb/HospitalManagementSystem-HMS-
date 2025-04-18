using HospitalManagementSystem_HMS_.DTOs;

namespace HospitalManagementSystem_HMS_.Services.AllPatients
{
    public interface IPatientService
    {
        Task<List<PatientDto>> GetAllPatientsAsync();
        Task<PatientDto> GetPatientByIdAsync(string id);
        Task AddPatientAsync(PatientDto dto);
    }
}
