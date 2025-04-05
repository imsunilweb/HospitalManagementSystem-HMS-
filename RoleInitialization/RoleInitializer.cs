using Microsoft.AspNetCore.Identity;

namespace HospitalManagementSystem_HMS_.RoleInitialization
{
    public static class RoleInitializer
    {
        public static async Task InitializeRoles(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            string[] roleNames = { "Admin", "Doctor", "Patient", "Staff" };
            foreach (var role in roleNames)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }
    }
}
