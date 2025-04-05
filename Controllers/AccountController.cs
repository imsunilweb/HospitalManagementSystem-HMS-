using HospitalManagementSystem_HMS_.IdentityModels;
using HospitalManagementSystem_HMS_.JWTDTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HospitalManagementSystem_HMS_.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // ✅ Register View GET
        [HttpGet]
        public IActionResult Register()
        {
            ViewBag.Roles = new List<string> { "Admin", "Doctor", "Patient", "Staff" };
            ViewBag.BloodGroups = new List<string> { "A+", "A-", "B+", "B-", "AB+", "AB-", "O+", "O-" };

            return View();
        }

        // ✅ Register POST
        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto model)
        {
            if (!ModelState.IsValid) return View(model);

            var user = new ApplicationUser
            {
                UserName = model.Email,  // Username ko Email set kar diya
                Email = model.Email,
                FullName = model.FullName,
                BloodGroup = model.BloodGroup,
                DOB = model.DOB,
                Gender = model.Gender,
                Address = model.Address,
                HealthScheme = model.HealthScheme // ✅ Directly assign without Enum.TryParse
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                // Yeh line role assign karti hai
                await _userManager.AddToRoleAsync(user, model.Role);

                await _signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToAction("Login", "Account");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View(model);
        }

        // ✅ Login View GET
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // ✅ Login POST
        [HttpPost]
        public async Task<IActionResult> Login(LoginDto model)
        {
            if (!ModelState.IsValid) return View(model);

            // ✅ First, find the user by email
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                ModelState.AddModelError("", "Invalid login attempt.");
                return View(model);
            }

            // ✅ Use username instead of email for signing in
            var result = await _signInManager.PasswordSignInAsync(user.UserName, model.Password, false, false);
            if (result.Succeeded)
            {
                // ✅ Role-based redirection
                var roles = await _userManager.GetRolesAsync(user);

                if (roles.Contains("Admin"))
                    return RedirectToAction("Index", "AdminDashboard");

                else if (roles.Contains("Doctor"))
                    return RedirectToAction("Index", "DoctorDashboard");

                else if (roles.Contains("Patient"))
                    return RedirectToAction("Index", "PatientDashboard");

                else if (roles.Contains("Staff"))
                    return RedirectToAction("Index", "StaffDashboard");

                // Fallback
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Invalid login attempt.");
            return View(model);
        }


        // ✅ Logout (Allow both GET & POST)
        [HttpGet, HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
    }
}
