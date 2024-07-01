using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MIOTIC.Contexto;
using MIOTIC.Models;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Linq;

namespace MIOTIC.Controllers
{
    public class LoginController : Controller
    {
        private readonly MiContexto _contexto;

        public LoginController(MiContexto contexto)
        {
            _contexto = contexto;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            var usuario = await _contexto.Usuarios
                                         .Where(x => x.Email == email && x.Password == password)
                                         .FirstOrDefaultAsync();

            if (usuario != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, usuario.Email ?? string.Empty),
                    new Claim(ClaimTypes.Role, usuario.Rol.ToString() ?? string.Empty)
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["LoginError"] = "Cuenta o Password incorrectos";
                return RedirectToAction("Index");
            }
        }

        public async Task<IActionResult Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index");
    }
}
}
