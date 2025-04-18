using AutoMapper;
using HospitalManagementSystem_HMS_.Data_Set;
using HospitalManagementSystem_HMS_.DTOs;
using HospitalManagementSystem_HMS_.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem_HMS_.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly HospitalDbContext _context;
        private readonly IMapper _mapper;

        public AppointmentService(HospitalDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<AppointmentDto>> GetAllAppointmentsAsync()
        {
            var appointments = await _context.Appointments.ToListAsync();
            return _mapper.Map<List<AppointmentDto>>(appointments);
        }

        public async Task<AppointmentDto> GetAppointmentByIdAsync(string id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            return _mapper.Map<AppointmentDto>(appointment);
        }

        public async Task AddAppointmentAsync(AppointmentDto dto)
        {
            var appointment = _mapper.Map<Appointment>(dto);
            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateStatusAsync(string id, string newStatus)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (Enum.TryParse<AppointmentStatus>(newStatus, out var parsedStatus))
            {
                appointment.Status = parsedStatus;
            }
        }
    }

}
