using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MIOTIC.Contexto;

namespace MIOTIC.Controllers
{
    public class LoginController : Controller
    {
        MiContexto _contexto;
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
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["LoginError"] = "Cuenta o Password incorrectos";
                return RedirectToAction("Index", "Login");
            }
        }
        
        public async Task<IActionResult> Logout()
        {
                return RedirectToAction("Index", "Login");
        }


    }
}
