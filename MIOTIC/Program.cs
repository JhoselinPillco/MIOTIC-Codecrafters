/*using Microsoft.EntityFrameworkCore;
using MIOTIC.Contexto;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<MiContexto>(options => {
    options.UseSqlite(builder.Configuration.GetConnectionString("CadenaConexion"));
});
builder.Services.AddRazorPages();
builder.Services.AddAuthorization();
builder.Services.AddAuthentication("MyCookieAuth").AddCookie("MyCookieAuth", options =>
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

// Configurar una redirección de la ruta principal al archivo index.html
app.MapGet("/", async context =>
{
    context.Response.Redirect("/index.html");
});

app.MapFallbackToFile("/index.html");
app.MapFallbackToFile("/contacto.html");
app.MapFallbackToFile("/servicios.html");

app.Run();
*/
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using MIOTIC.Contexto;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<MiContexto>(options => {
    options.UseSqlite(builder.Configuration.GetConnectionString("CadenaConexion"));
});
builder.Services.AddRazorPages();
builder.Services.AddAuthorization();
builder.Services.AddAuthentication("MyCookieAuth").AddCookie("MyCookieAuth", options =>
{
    options.Cookie.Name = "MyCookieAuth";
    options.LoginPath = "/Login/Index"; // Ruta al formulario de inicio de sesión
    options.AccessDeniedPath = "/Account/AccessDenied"; // Ruta de acceso denegado
});
//Cookies, para usuarios 
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(option =>
    {
        option.LoginPath = "/Login/Index"; //tal vez cambiar al del hans
        option.ExpireTimeSpan = TimeSpan.FromMinutes(30);
        option.AccessDeniedPath = "/Home/Privacy";
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

// Configurar una redirección de la ruta principal al archivo index.html
app.MapGet("/", async context =>
{
    context.Response.Redirect("/index.html");
});

app.MapFallbackToFile("/index.html");
app.MapFallbackToFile("/contacto.html");
app.MapFallbackToFile("/servicios.html");

app.Run();
