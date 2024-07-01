using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MIOTIC.Contexto;
using MIOTIC.Models;
using System.Threading.Tasks;

namespace MIOTIC.Controllers
{
    public class InicioController : Controller
    {
        private readonly MiContexto _contexto;

        public InicioController(MiContexto contexto)
        {
            this._contexto = contexto;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Contacto(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inicio = await _contexto.Inicio
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inicio == null)
            {
                return NotFound();
            }

            return View(inicio);
        }
    }
}
