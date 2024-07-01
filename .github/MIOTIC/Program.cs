using Microsoft.EntityFrameworkCore;
using MIOTIC.Contexto;
using Microsoft.AspNetCore.Authentication.Cookies;
using MIOTIC.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<MiContexto>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("CadenaConexion"));
});
builder.Services.AddRazorPages();
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy => policy.RequireRole(RolEnum.Admin.ToString()));
    options.AddPolicy("SeniorDevPolicy", policy => policy.RequireRole(RolEnum.SeniorDev.ToString()));
});
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
    {
        options.Cookie.Name = "MyCookieAuth";
        options.LoginPath = "/Login/Index"; // Ruta al formulario de inicio de sesión
        options.AccessDeniedPath = "/Account/AccessDenied"; // Ruta de acceso denegado
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
