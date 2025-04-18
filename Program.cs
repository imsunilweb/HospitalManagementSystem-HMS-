using HospitalManagementSystem_HMS_.Data_Set;
using HospitalManagementSystem_HMS_.IdentityModels;
using HospitalManagementSystem_HMS_.JWTDTOs;
using HospitalManagementSystem_HMS_.RoleInitialization;
using HospitalManagementSystem_HMS_.Services;
using HospitalManagementSystem_HMS_.Services.AllDoctor;
using HospitalManagementSystem_HMS_.Services.AllPatients;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// 👇 AutoMapper service registration
builder.Services.AddAutoMapper(typeof(Program)); // or typeof(AdminProfile).Assembly

// ✅ Bind JwtSettings from appsettings.json
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();
builder.Services.AddScoped<IPatientService,PatientService>();
builder.Services.AddScoped<IDoctorService, DoctorService>();

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<HospitalDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddDbContext<HospitalDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("HospitalConnection"));
});



// ✅ Add JWT Authentication
var jwtSettings = builder.Configuration.GetSection("JwtSettings").Get<JwtSettings>();
var key = Encoding.UTF8.GetBytes(jwtSettings.Secret);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidIssuer = jwtSettings.Issuer,
            ValidAudience = jwtSettings.Audience,
            ValidateLifetime = true
        };
    });

var app = builder.Build();

using (var scope = app.Services.CreateScope()) // ✅ Fir use karo
{
    var services = scope.ServiceProvider;
    await RoleInitializer.InitializeRoles(services);
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    await RoleInitializer.InitializeRoles(services);
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Register}/{id?}");

await app.RunAsync();
