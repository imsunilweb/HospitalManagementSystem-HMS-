using HospitalManagementSystem_HMS_.JWTDTOs;

namespace HospitalManagementSystem_HMS_.Services
{
    public interface IAuthService
    {
        Task<string> RegisterAsync(RegisterDto registerDto);
        Task<string> LoginAsync(LoginDto loginDto);
    }
}
