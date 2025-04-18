using AutoMapper;
using HospitalManagementSystem_HMS_.Data_Set;
using HospitalManagementSystem_HMS_.DTOs;
using HospitalManagementSystem_HMS_.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem_HMS_.Services
{
    public class AdminService : IAdminService
    {
        private readonly HospitalDbContext _context;
        private readonly IMapper _mapper;

        public AdminService(HospitalDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<AdminDto>> GetAllAdminsAsync()
        {
            var admins = await _context.Admins.ToListAsync();
            return _mapper.Map<List<AdminDto>>(admins);
        }

        public async Task<AdminDto> GetAdminByIdAsync(string id)
        {
            var admin = await _context.Admins.FindAsync(id);
            return _mapper.Map<AdminDto>(admin);
        }

        public async Task AddAdminAsync(AdminDto dto)
        {
            var admin = _mapper.Map<Admin>(dto);
            _context.Admins.Add(admin);
            await _context.SaveChangesAsync();
        }
    }

}
