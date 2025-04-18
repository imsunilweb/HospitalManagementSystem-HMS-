using HospitalManagementSystem_HMS_.DTOs;
using HospitalManagementSystem_HMS_.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem_HMS_.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var admins = await _adminService.GetAllAdminsAsync();
            return View(admins);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AdminDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            await _adminService.AddAdminAsync(dto);
            return RedirectToAction("Index");
        }
    }

}
