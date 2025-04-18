using HospitalManagementSystem_HMS_.DTOs;
using HospitalManagementSystem_HMS_.IdentityModels;
using HospitalManagementSystem_HMS_.Services.AllPatients;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem_HMS_.Controllers
{
   [Authorize(Roles = "Admin,Doctor")]
    public class PatientController : Controller
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var patients = await _patientService.GetAllPatientsAsync();
            return View(patients);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.HealthSchemes = Enum.GetValues(typeof(HealthSchemeType));
            ViewBag.BloodGroups = new List<string> { "A+", "A-", "B+", "B-", "AB+", "AB-", "O+", "O-" };
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PatientDto dto)
        {
            if (!ModelState.IsValid)
            {
                foreach (var key in ModelState.Keys)
                {
                    var errors = ModelState[key].Errors;
                    foreach (var error in errors)
                    {
                        Console.WriteLine($"{key}: {error.ErrorMessage}");
                    }
                }

                ViewBag.HealthSchemes = Enum.GetValues(typeof(HealthSchemeType));
                ViewBag.BloodGroups = new List<string> { "A+", "A-", "B+", "B-", "AB+", "AB-", "O+", "O-" };
                return View(dto);
            }

            await _patientService.AddPatientAsync(dto);
            return RedirectToAction("Index");
        }
    }

}
