using HospitalManagementSystem_HMS_.DTOs;
using HospitalManagementSystem_HMS_.Services.AllDoctor;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem_HMS_.Controllers
{
     [Authorize(Roles = "Admin,Doctor")]
    public class DoctorController : Controller
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        public async Task<IActionResult> Index()
        {
            var doctors = await _doctorService.GetAllDoctorsAsync();
            return View(doctors);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(DoctorDto dto)
        {
            if (!ModelState.IsValid) return View(dto);

            await _doctorService.AddDoctorAsync(dto);
            return RedirectToAction("Index");   
        }

        public async Task<IActionResult> Edit(int id)
        {
            var doctor = await _doctorService.GetDoctorByIdAsync(id);
            return doctor == null ? NotFound() : View(doctor);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(DoctorDto dto)
        {
            if (!ModelState.IsValid) return View(dto);

            await _doctorService.UpdateDoctorAsync(dto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _doctorService.DeleteDoctorAsync(id);
            return RedirectToAction("Index");
        }

        // ✅ NEW ACTION: Patients under a specific doctor
        public async Task<IActionResult> Patients(int id)
        {
            var patients = await _doctorService.GetPatientsForDoctorAsync(id);
            return View(patients); // You need a Razor view named "Patients.cshtml"
        }
    }
}
 