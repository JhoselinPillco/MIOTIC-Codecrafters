using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MIOTIC.Contexto;
using MIOTIC.Dto;
using MIOTIC.Models;
using System.Security.Claims;

namespace MIOTIC.Controllers
{
    public class LoginController : Controller
    {
        private MiContexto _contexto;
        public LoginController(MiContexto contexto)
        {
            this._contexto = contexto;
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
                await SetUserCookie(usuario);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["LoginError"] = "Cuenta o password incorrecto!";
                return RedirectToAction("Index");
            }
        }
        private async Task SetUserCookie(Usuario usuario)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, usuario!.Nombre!),
                new Claim(ClaimTypes.Email, usuario!.Email!),
                new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                new Claim(ClaimTypes.Role, usuario.Rol!.ToString()),
            };
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Login");
        }


    }
}



