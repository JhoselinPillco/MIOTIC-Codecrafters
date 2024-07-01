using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MIOTIC.Controllers
{
    [Authorize(Roles = "SeniorDev")]
    public class AvanceDeProyectoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // Agrega más acciones según sea necesario
    }
}
