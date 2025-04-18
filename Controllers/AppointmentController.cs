using HospitalManagementSystem_HMS_.DTOs;
using HospitalManagementSystem_HMS_.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using HospitalManagementSystem_HMS_.Data_Set; // For HospitalDbContext
using Microsoft.AspNetCore.Authorization;

namespace HospitalManagementSystem_HMS_.Controllers
{
    [Authorize(Roles = "Admin,Doctor")]
    public class AppointmentController : Controller
    {
        private readonly IAppointmentService _appointmentService;
        private readonly HospitalDbContext _context;

        public AppointmentController(IAppointmentService appointmentService, HospitalDbContext context)
        {
            _appointmentService = appointmentService;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var appointments = await _appointmentService.GetAllAppointmentsAsync();
            return View(appointments);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.StatusList = new SelectList(Enum.GetValues(typeof(AppointmentStatus)));
            ViewBag.Patients = _context.Patients.Select(p => new SelectListItem
            {
                Value = p.Patient_ID.ToString(),
                Text = p.Name
            }).ToList();

            ViewBag.Doctors = _context.Doctors.Select(d => new SelectListItem
            {
                Value = d.Doctor_ID.ToString(),
                Text = d.Doctor_ID.ToString() // Or d.Name if Name exists
            }).ToList();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AppointmentDto dto)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.StatusList = new SelectList(Enum.GetValues(typeof(AppointmentStatus)));
                // Reload dropdowns in case of validation failure
                ViewBag.Patients = _context.Patients.Select(p => new SelectListItem
                {
                    Value = p.Patient_ID.ToString(),
                    Text = p.Name
                }).ToList();

                ViewBag.Doctors = _context.Doctors.Select(d => new SelectListItem
                {
                    Value = d.Doctor_ID.ToString(),
                    Text = d.Doctor_ID.ToString()
                }).ToList();

                return View(dto);
            }

            await _appointmentService.AddAppointmentAsync(dto);
            return RedirectToAction("Index");
        }
    }
}
