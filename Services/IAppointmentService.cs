using HospitalManagementSystem_HMS_.DTOs;

namespace HospitalManagementSystem_HMS_.Services
{
    public interface IAppointmentService
    {
        Task<List<AppointmentDto>> GetAllAppointmentsAsync();
        Task<AppointmentDto> GetAppointmentByIdAsync(string id);
        Task AddAppointmentAsync(AppointmentDto dto);
        Task UpdateStatusAsync(string id, string newStatus);
    }
}
