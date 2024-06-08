using Microsoft.AspNetCore.Mvc;

namespace MIOTIC.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
