using HospitalManagementSystem_HMS_.DTOs;

namespace HospitalManagementSystem_HMS_.Services
{
    public interface IAdminService
    {
        Task<List<AdminDto>> GetAllAdminsAsync();
        Task<AdminDto> GetAdminByIdAsync(string id);
        Task AddAdminAsync(AdminDto dto);
    }
}
